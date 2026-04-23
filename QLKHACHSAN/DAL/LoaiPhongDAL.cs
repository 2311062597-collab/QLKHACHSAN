using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class LoaiPhongDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetDanhSachLoaiPhong()
        {
            string query = @"
                SELECT MaLoaiPhong, TenLoaiPhong, Gia, MoTa
                FROM LoaiPhong";
            return db.ExecuteQuery(query);
        }

        public DataTable TimLoaiPhong(string tuKhoa)
        {
            string query = @"
                SELECT MaLoaiPhong, TenLoaiPhong, Gia, MoTa
                FROM LoaiPhong
                WHERE TenLoaiPhong LIKE @TuKhoa";

            SqlParameter[] param =
            {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            };

            return db.ExecuteQuery(query, param);
        }

        public bool KiemTraLoaiPhongTonTai(string tenLoaiPhong)
        {
            string query = "SELECT COUNT(*) FROM LoaiPhong WHERE TenLoaiPhong = @TenLoaiPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoaiPhong", tenLoaiPhong)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, param));
            return count > 0;
        }

        public bool ThemLoaiPhong(string tenLoaiPhong, decimal gia, string moTa)
        {
            string query = @"
                INSERT INTO LoaiPhong(TenLoaiPhong, Gia, MoTa)
                VALUES(@TenLoaiPhong, @Gia, @MoTa)";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoaiPhong", tenLoaiPhong),
                new SqlParameter("@Gia", gia),
                new SqlParameter("@MoTa", moTa)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool SuaLoaiPhong(int maLoaiPhong, string tenLoaiPhong, decimal gia, string moTa)
        {
            string query = @"
                UPDATE LoaiPhong
                SET TenLoaiPhong = @TenLoaiPhong,
                    Gia = @Gia,
                    MoTa = @MoTa
                WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoaiPhong", tenLoaiPhong),
                new SqlParameter("@Gia", gia),
                new SqlParameter("@MoTa", moTa),
                new SqlParameter("@MaLoaiPhong", maLoaiPhong)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool LoaiPhongDangDuocSuDung(int maLoaiPhong)
        {
            string query = "SELECT COUNT(*) FROM Phong WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiPhong", maLoaiPhong)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, param));
            return count > 0;
        }

        public bool XoaLoaiPhong(int maLoaiPhong)
        {
            string query = "DELETE FROM LoaiPhong WHERE MaLoaiPhong = @MaLoaiPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiPhong", maLoaiPhong)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }
    }
}