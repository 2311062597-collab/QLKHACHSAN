using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class PhongDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetDanhSachPhong()
        {
            string query = @"
                SELECT 
                    p.MaPhong,
                    p.SoPhong,
                    p.Tang,
                    p.MaLoaiPhong,
                    lp.TenLoaiPhong,
                    lp.Gia,
                    lp.MoTa,
                    p.TrangThai
                FROM Phong p
                INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong";

            return db.ExecuteQuery(query);
        }

        public DataTable TimPhong(string soPhong, string tang, string maLoaiPhong)
        {
            string query = @"
                SELECT 
                    p.MaPhong,
                    p.SoPhong,
                    p.Tang,
                    p.MaLoaiPhong,
                    lp.TenLoaiPhong,
                    lp.Gia,
                    lp.MoTa,
                    p.TrangThai
                FROM Phong p
                INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                WHERE (@SoPhong = '' OR p.SoPhong LIKE '%' + @SoPhong + '%')
                  AND (@Tang = '' OR CAST(p.Tang AS NVARCHAR(10)) = @Tang)
                  AND (@MaLoaiPhong = '' OR CAST(p.MaLoaiPhong AS NVARCHAR(10)) = @MaLoaiPhong)";

            SqlParameter[] param =
            {
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@Tang", tang),
                new SqlParameter("@MaLoaiPhong", maLoaiPhong)
            };

            return db.ExecuteQuery(query, param);
        }

        public DataTable GetLoaiPhong()
        {
            string query = "SELECT MaLoaiPhong, TenLoaiPhong, Gia, MoTa FROM LoaiPhong";
            return db.ExecuteQuery(query);
        }

        public bool ThemPhong(string soPhong, int tang, int maLoaiPhong, string trangThai)
        {
            string query = @"
                INSERT INTO Phong(SoPhong, Tang, MaLoaiPhong, TrangThai)
                VALUES(@SoPhong, @Tang, @MaLoaiPhong, @TrangThai)";

            SqlParameter[] param =
            {
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@Tang", tang),
                new SqlParameter("@MaLoaiPhong", maLoaiPhong),
                new SqlParameter("@TrangThai", trangThai)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool SuaPhong(int maPhong, string soPhong, int tang, int maLoaiPhong, string trangThai)
        {
            string query = @"
                UPDATE Phong
                SET SoPhong = @SoPhong,
                    Tang = @Tang,
                    MaLoaiPhong = @MaLoaiPhong,
                    TrangThai = @TrangThai
                WHERE MaPhong = @MaPhong";

            SqlParameter[] param =
            {
                new SqlParameter("@SoPhong", soPhong),
                new SqlParameter("@Tang", tang),
                new SqlParameter("@MaLoaiPhong", maLoaiPhong),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaPhong", maPhong)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }
    }
}