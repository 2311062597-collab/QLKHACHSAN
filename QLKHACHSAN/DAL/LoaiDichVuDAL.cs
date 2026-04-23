using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class LoaiDichVuDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetDanhSachLoaiDichVu()
        {
            string query = @"
                SELECT MaLoaiDichVu, TenLoaiDichVu, DonViTinh
                FROM LoaiDichVu";

            return db.ExecuteQuery(query);
        }

        public DataTable TimLoaiDichVu(string tuKhoa)
        {
            string query = @"
                SELECT MaLoaiDichVu, TenLoaiDichVu, DonViTinh
                FROM LoaiDichVu
                WHERE TenLoaiDichVu LIKE @TuKhoa";

            SqlParameter[] param =
            {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            };

            return db.ExecuteQuery(query, param);
        }

        public bool KiemTraLoaiDichVuTonTai(string tenLoai)
        {
            string query = "SELECT COUNT(*) FROM LoaiDichVu WHERE TenLoaiDichVu = @TenLoai";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoai", tenLoai)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, param));
            return count > 0;
        }

        public bool ThemLoaiDichVu(string tenLoai, string donViTinh)
        {
            string query = @"
                INSERT INTO LoaiDichVu(TenLoaiDichVu, DonViTinh)
                VALUES(@TenLoai, @DonViTinh)";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoai", tenLoai),
                new SqlParameter("@DonViTinh", donViTinh)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool SuaLoaiDichVu(int maLoaiDichVu, string tenLoai, string donViTinh)
        {
            string query = @"
                UPDATE LoaiDichVu
                SET TenLoaiDichVu = @TenLoai,
                    DonViTinh = @DonViTinh
                WHERE MaLoaiDichVu = @MaLoaiDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoai", tenLoai),
                new SqlParameter("@DonViTinh", donViTinh),
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool LoaiDichVuConDichVu(int maLoaiDichVu)
        {
            string query = "SELECT COUNT(*) FROM DichVu WHERE MaLoaiDichVu = @MaLoaiDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, param));
            return count > 0;
        }

        public bool LoaiDichVuDangDuocKhachSuDung(int maLoaiDichVu)
        {
            string query = @"
                SELECT COUNT(*)
                FROM DatDichVu ddv
                INNER JOIN DichVu dv ON ddv.MaDichVu = dv.MaDichVu
                WHERE dv.MaLoaiDichVu = @MaLoaiDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu)
            };

            int count = Convert.ToInt32(db.ExecuteScalar(query, param));
            return count > 0;
        }

        public bool XoaLoaiDichVu(int maLoaiDichVu)
        {
            string query = "DELETE FROM LoaiDichVu WHERE MaLoaiDichVu = @MaLoaiDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }
    }
}