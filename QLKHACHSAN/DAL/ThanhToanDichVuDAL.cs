using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for Service Payment (ThanhToanDichVu)
    /// Handles database operations for service purchase payments
    /// </summary>
    public class ThanhToanDichVuDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Save service payment to database
        /// </summary>
        public bool SavePayment(string maKhachHang, string maNhanVien, string maDichVu,
                                int soLuong, decimal thanhTien, string phuongThuc, DateTime ngayThanhToan)
        {
            try
            {
                string query = @"
                    INSERT INTO DatDichVu (
                        MaKhachHang,
                        MaNhanVien,
                        MaDichVu,
                        SoLuong,
                        ThanhTien,
                        MaPhuongThuc,
                        NgayThanhToan)
                    VALUES (
                        @MaKhachHang,
                        @MaNhanVien,
                        @MaDichVu,
                        @SoLuong,
                        @ThanhTien,
                        @MaPhuongThuc,
                        @NgayThanhToan)";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhachHang", maKhachHang),
                    new SqlParameter("@MaNhanVien", maNhanVien),
                    new SqlParameter("@MaDichVu", maDichVu),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@ThanhTien", thanhTien),
                    new SqlParameter("@MaPhuongThuc", phuongThuc),
                    new SqlParameter("@NgayThanhToan", ngayThanhToan)
                };

                int result = db.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lưu thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get service details by service ID
        /// </summary>
        public DataTable GetServiceDetails(string maDichVu)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaDichVu,
                        TenDichVu,
                        DonGia,
                        MoTa
                    FROM DichVu
                    WHERE MaDichVu = @MaDichVu";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDichVu", maDichVu)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get customer details by customer ID
        /// </summary>
        public DataTable GetCustomerDetails(string maKhachHang)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaKhachHang,
                        TenKhachHang,
                        SoDienThoai,
                        Email,
                        DiaChi
                    FROM KhachHang
                    WHERE MaKhachHang = @MaKhachHang";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhachHang", maKhachHang)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get payment receipt by service purchase ID
        /// </summary>
        public DataTable GetPaymentReceipt(string maDatDichVu)
        {
            try
            {
                string query = @"
                    SELECT 
                        dd.MaDatDichVu,
                        dd.MaKhachHang,
                        kh.TenKhachHang,
                        dd.MaNhanVien,
                        nv.HoTen AS TenNhanVien,
                        dd.MaDichVu,
                        dv.TenDichVu,
                        dd.SoLuong,
                        dd.ThanhTien,
                        dd.MaPhuongThuc,
                        dd.NgayThanhToan
                    FROM DatDichVu dd
                    LEFT JOIN KhachHang kh ON dd.MaKhachHang = kh.MaKhachHang
                    LEFT JOIN NhanVien nv ON dd.MaNhanVien = nv.MaNhanVien
                    LEFT JOIN DichVu dv ON dd.MaDichVu = dv.MaDichVu
                    WHERE dd.MaDatDichVu = @MaDatDichVu";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDatDichVu", maDatDichVu)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy hóa đơn: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Check if service payment already exists
        /// </summary>
        public bool CheckPaymentExists(string maDatDichVu)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) FROM DatDichVu 
                    WHERE MaDatDichVu = @MaDatDichVu";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaDatDichVu", maDatDichVu)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]) > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
