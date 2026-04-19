using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class KhachHangDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetAll()
        {
            string query = "SELECT * FROM KhachHang";
            return db.ExecuteQuery(query);
        }

        public DataTable Tim(string keyword)
        {
            string query = @"
                SELECT * FROM KhachHang
                WHERE HoTen LIKE @kw
                   OR SoDienThoai LIKE @kw";

            SqlParameter[] param =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            return db.ExecuteQuery(query, param);
        }

        public bool Sua(int maKH, string ten, string sdt, string cccd)
        {
            string query = @"
                UPDATE KhachHang
                SET HoTen = @ten,
                    SoDienThoai = @sdt,
                    CCCD = @cccd
                WHERE MaKhachHang = @id";

            SqlParameter[] param =
            {
                new SqlParameter("@ten", ten),
                new SqlParameter("@sdt", sdt),
                new SqlParameter("@cccd", cccd),
                new SqlParameter("@id", maKH)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }
        public bool Them(string ten, string sdt, string cccd)
        {
            string query = @"
            INSERT INTO KhachHang(HoTen, SoDienThoai, CCCD)
            VALUES (@ten, @sdt, @cccd)";

            SqlParameter[] param =
            {
             new SqlParameter("@ten", ten),
             new SqlParameter("@sdt", sdt),
             new SqlParameter("@cccd", cccd)
             };

            return db.ExecuteNonQuery(query, param) > 0;
        }

    }
}