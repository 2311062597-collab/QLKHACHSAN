using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace QLKHACHSAN.DAL
{
    public class CheckoutDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetThongTinCheckout(int maDatPhong)
        {
            try
            {
                string query = @"
                    SELECT 
                        dp.MaDatPhong,
                        dp.MaPhong,
                        dp.MaKhachHang,
                        dp.NgayNhan,
                        dp.NgayTra,
                        dp.TrangThai AS TrangThaiDatPhong,

                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.CCCD,

                        p.SoPhong,
                        p.TrangThai AS TrangThaiPhong,

                        lp.TenLoaiPhong,
                        lp.Gia AS DonGia,

                        CASE 
                            WHEN DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra)
                        END AS SoNgay,

                        lp.Gia *
                        CASE 
                            WHEN DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra)
                        END AS ThanhTien
                    FROM DatPhong dp
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE dp.MaDatPhong = @MaDatPhong";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@MaDatPhong", maDatPhong)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowSqlError("Lỗi khi lấy thông tin checkout", ex);
                return new DataTable();
            }
        }

        public DataTable GetDanhSachPhuongThuc()
        {
            try
            {
                string query = @"
                    SELECT 
                        MaPhuongThuc,
                        TenPhuongThuc
                    FROM PhuongThucThanhToan
                    ORDER BY TenPhuongThuc";

                return db.ExecuteQuery(query, null);
            }
            catch (Exception ex)
            {
                ShowSqlError("Lỗi khi lấy danh sách phương thức thanh toán", ex);
                // Return empty datatable as fallback
                DataTable dt = new DataTable();
                dt.Columns.Add("MaPhuongThuc", typeof(int));
                dt.Columns.Add("TenPhuongThuc", typeof(string));
                return dt;
            }
        }

        public bool ThanhToanVaCheckout(int maDatPhong, int maPhuongThuc, decimal soTien, DateTime ngayTra, string ghiChu)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = db.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                int maPhong = LayMaPhongTheoMaDatPhong(maDatPhong, conn, tran);

                if (maPhong <= 0)
                {
                    tran.Rollback();
                    return false;
                }

                ThemThanhToanDatPhong(maDatPhong, maPhuongThuc, soTien, ghiChu, conn, tran);
                CapNhatDatPhongDaTraPhong(maDatPhong, ngayTra, conn, tran);
                CapNhatPhongConTrong(maPhong, conn, tran);

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    if (tran != null)
                        tran.Rollback();
                }
                catch (Exception rollbackEx)
                {
                    Debug.WriteLine("===== ROLLBACK ERROR =====");
                    Debug.WriteLine(rollbackEx.ToString());
                }

                ShowSqlError("Lỗi khi thanh toán và checkout", ex);
                return false;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }

        private int LayMaPhongTheoMaDatPhong(int maDatPhong, SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                SELECT MaPhong
                FROM DatPhong
                WHERE MaDatPhong = @MaDatPhong";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);

                object result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                return Convert.ToInt32(result);
            }
        }

        private void ThemThanhToanDatPhong(
            int maDatPhong,
            int maPhuongThuc,
            decimal soTien,
            string ghiChu,
            SqlConnection conn,
            SqlTransaction tran)
        {
            string query = @"
                INSERT INTO ThanhToanDatPhong
                (
                    MaDatPhong,
                    MaPhuongThuc,
                    SoTien,
                    NgayThanhToan,
                    TrangThai,
                    GhiChu
                )
                VALUES
                (
                    @MaDatPhong,
                    @MaPhuongThuc,
                    @SoTien,
                    GETDATE(),
                    N'Đã thanh toán',
                    @GhiChu
                )";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                cmd.Parameters.AddWithValue("@MaPhuongThuc", maPhuongThuc);
                cmd.Parameters.AddWithValue("@SoTien", soTien);
                cmd.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(ghiChu) ? "" : ghiChu);

                cmd.ExecuteNonQuery();
            }
        }

        private void CapNhatDatPhongDaTraPhong(
            int maDatPhong,
            DateTime ngayTra,
            SqlConnection conn,
            SqlTransaction tran)
        {
            string query = @"
                UPDATE DatPhong
                SET TrangThai = N'Đã trả phòng',
                    NgayTra = @NgayTra
                WHERE MaDatPhong = @MaDatPhong";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaDatPhong", maDatPhong);
                cmd.Parameters.AddWithValue("@NgayTra", ngayTra.Date);

                cmd.ExecuteNonQuery();
            }
        }

        private void CapNhatPhongConTrong(int maPhong, SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
                UPDATE Phong
                SET TrangThai = N'Còn trống'
                WHERE MaPhong = @MaPhong";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

        private void ShowSqlError(string message, Exception ex)
        {
            Debug.WriteLine("===== CHECKOUT DAL ERROR =====");
            Debug.WriteLine(message);
            Debug.WriteLine(ex.ToString());

            MessageBox.Show(
                message + ": " + ex.Message +
                "\n\nChi tiết xem ở Output của Visual Studio.",
                "Lỗi SQL",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}