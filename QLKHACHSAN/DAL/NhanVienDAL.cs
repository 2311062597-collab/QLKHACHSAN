using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class NhanVienDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetDanhSachNhanVien()
        {
            string query = @"
                SELECT 
                    nv.MaNhanVien,
                    nv.MaTaiKhoan,
                    tk.MaChucVu,
                    tk.TenDangNhap,
                    tk.MatKhau,
                    tk.TrangThai,
                    cv.TenChucVu,
                    cv.Luong,
                    nv.HoTen,
                    nv.CCCD,
                    nv.SoDienThoai,
                    nv.GioiTinh,
                    nv.DiaChi
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
                INNER JOIN ChucVu cv ON tk.MaChucVu = cv.MaChucVu";

            return db.ExecuteQuery(query);
        }

        public DataTable TimNhanVien(string tuKhoa)
        {
            string query = @"
                SELECT 
                    nv.MaNhanVien,
                    nv.MaTaiKhoan,
                    tk.MaChucVu,
                    tk.TenDangNhap,
                    tk.MatKhau,
                    tk.TrangThai,
                    cv.TenChucVu,
                    cv.Luong,
                    nv.HoTen,
                    nv.CCCD,
                    nv.SoDienThoai,
                    nv.GioiTinh,
                    nv.DiaChi
                FROM NhanVien nv
                INNER JOIN TaiKhoan tk ON nv.MaTaiKhoan = tk.MaTaiKhoan
                INNER JOIN ChucVu cv ON tk.MaChucVu = cv.MaChucVu
                WHERE tk.TenDangNhap LIKE @TuKhoa
                   OR nv.HoTen LIKE @TuKhoa
                   OR nv.SoDienThoai LIKE @TuKhoa";

            SqlParameter[] param =
            {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            };

            return db.ExecuteQuery(query, param);
        }

        public DataTable GetChucVu()
        {
            string query = "SELECT MaChucVu, TenChucVu, Luong FROM ChucVu";
            return db.ExecuteQuery(query);
        }

        public bool ThemNhanVien(
            string tenDangNhap,
            string matKhau,
            int maChucVu,
            string trangThai,
            string hoTen,
            string cccd,
            string sdt,
            string gioiTinh,
            string diaChi)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string insertTaiKhoan = @"
                        INSERT INTO TaiKhoan(TenDangNhap, MatKhau, MaChucVu, TrangThai)
                        VALUES(@TenDangNhap, @MatKhau, @MaChucVu, @TrangThai);
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdTK = new SqlCommand(insertTaiKhoan, conn, tran);
                    cmdTK.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmdTK.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmdTK.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    cmdTK.Parameters.AddWithValue("@TrangThai", trangThai);

                    int maTaiKhoan = Convert.ToInt32(cmdTK.ExecuteScalar());

                    string insertNhanVien = @"
                        INSERT INTO NhanVien(HoTen, CCCD, SoDienThoai, GioiTinh, DiaChi, MaTaiKhoan)
                        VALUES(@HoTen, @CCCD, @SoDienThoai, @GioiTinh, @DiaChi, @MaTaiKhoan)";

                    SqlCommand cmdNV = new SqlCommand(insertNhanVien, conn, tran);
                    cmdNV.Parameters.AddWithValue("@HoTen", hoTen);
                    cmdNV.Parameters.AddWithValue("@CCCD", cccd);
                    cmdNV.Parameters.AddWithValue("@SoDienThoai", sdt);
                    cmdNV.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmdNV.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmdNV.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

                    cmdNV.ExecuteNonQuery();

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        public bool SuaNhanVien(
            int maNhanVien,
            int maTaiKhoan,
            string tenDangNhap,
            string matKhau,
            int maChucVu,
            string trangThai,
            string hoTen,
            string cccd,
            string sdt,
            string gioiTinh,
            string diaChi)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string updateTaiKhoan = @"
                        UPDATE TaiKhoan
                        SET TenDangNhap = @TenDangNhap,
                            MatKhau = @MatKhau,
                            MaChucVu = @MaChucVu,
                            TrangThai = @TrangThai
                        WHERE MaTaiKhoan = @MaTaiKhoan";

                    SqlCommand cmdTK = new SqlCommand(updateTaiKhoan, conn, tran);
                    cmdTK.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmdTK.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmdTK.Parameters.AddWithValue("@MaChucVu", maChucVu);
                    cmdTK.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmdTK.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cmdTK.ExecuteNonQuery();

                    string updateNhanVien = @"
                        UPDATE NhanVien
                        SET HoTen = @HoTen,
                            CCCD = @CCCD,
                            SoDienThoai = @SoDienThoai,
                            GioiTinh = @GioiTinh,
                            DiaChi = @DiaChi
                        WHERE MaNhanVien = @MaNhanVien";

                    SqlCommand cmdNV = new SqlCommand(updateNhanVien, conn, tran);
                    cmdNV.Parameters.AddWithValue("@HoTen", hoTen);
                    cmdNV.Parameters.AddWithValue("@CCCD", cccd);
                    cmdNV.Parameters.AddWithValue("@SoDienThoai", sdt);
                    cmdNV.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmdNV.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmdNV.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cmdNV.ExecuteNonQuery();

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }
    }
}