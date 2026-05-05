using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class TaiKhoanDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetThongTinTaiKhoan(int maTaiKhoan)
        {
            string query = @"
                SELECT 
                    tk.MaTaiKhoan,
                    tk.TenDangNhap,
                    tk.TrangThai,
                    cv.TenChucVu,
                    nv.MaNhanVien,
                    nv.HoTen,
                    nv.CCCD,
                    nv.SoDienThoai,
                    nv.GioiTinh,
                    nv.DiaChi
                FROM TaiKhoan tk
                LEFT JOIN ChucVu cv ON tk.MaChucVu = cv.MaChucVu
                LEFT JOIN NhanVien nv ON tk.MaTaiKhoan = nv.MaTaiKhoan
                WHERE tk.MaTaiKhoan = @MaTaiKhoan";

            SqlParameter[] param =
            {
                new SqlParameter("@MaTaiKhoan", maTaiKhoan)
            };

            return db.ExecuteQuery(query, param);
        }
    }
}
