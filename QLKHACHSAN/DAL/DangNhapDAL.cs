using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class DangNhapDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            string query = @"
                SELECT tk.MaTaiKhoan, tk.TenDangNhap, tk.MatKhau, tk.TrangThai,
                       tk.MaChucVu, cv.TenChucVu
                FROM TaiKhoan tk
                INNER JOIN ChucVu cv ON tk.MaChucVu = cv.MaChucVu
                WHERE tk.TenDangNhap = @TenDangNhap
                  AND tk.MatKhau = @MatKhau";

            SqlParameter[] param =
            {
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau", matKhau)
            };

            return db.ExecuteQuery(query, param);
        }
    }
}