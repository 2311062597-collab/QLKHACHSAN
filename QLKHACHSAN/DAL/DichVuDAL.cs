using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    public class DichVuDAL
    {
        private DBConnection db = new DBConnection();

        public DataTable GetDanhSachDichVu()
        {
            string query = @"
                SELECT 
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.MaLoaiDichVu,
                    ldv.TenLoaiDichVu,
                    ldv.DonViTinh,
                    dv.DonGia,
                    dv.MoTa,
                    dv.TrangThai
                FROM DichVu dv
                INNER JOIN LoaiDichVu ldv ON dv.MaLoaiDichVu = ldv.MaLoaiDichVu";

            return db.ExecuteQuery(query);
        }

        public DataTable TimDichVu(string tuKhoa)
        {
            string query = @"
                SELECT 
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.MaLoaiDichVu,
                    ldv.TenLoaiDichVu,
                    ldv.DonViTinh,
                    dv.DonGia,
                    dv.MoTa,
                    dv.TrangThai
                FROM DichVu dv
                INNER JOIN LoaiDichVu ldv ON dv.MaLoaiDichVu = ldv.MaLoaiDichVu
                WHERE dv.TenDichVu LIKE @TuKhoa
                   OR CAST(dv.MaDichVu AS NVARCHAR(20)) LIKE @TuKhoa";

            SqlParameter[] param =
            {
                new SqlParameter("@TuKhoa", "%" + tuKhoa + "%")
            };

            return db.ExecuteQuery(query, param);
        }

        public DataTable GetLoaiDichVu()
        {
            string query = "SELECT MaLoaiDichVu, TenLoaiDichVu, DonViTinh FROM LoaiDichVu";
            return db.ExecuteQuery(query);
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

        public int ThemLoaiDichVu(string tenLoai, string donViTinh)
        {
            string query = @"
                INSERT INTO LoaiDichVu(TenLoaiDichVu, DonViTinh)
                VALUES(@TenLoai, @DonViTinh);
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] param =
            {
                new SqlParameter("@TenLoai", tenLoai),
                new SqlParameter("@DonViTinh", donViTinh)
            };

            return Convert.ToInt32(db.ExecuteScalar(query, param));
        }

        public bool ThemDichVu(string tenDichVu, int maLoaiDichVu, decimal donGia, string moTa, string trangThai)
        {
            string query = @"
                INSERT INTO DichVu(TenDichVu, MaLoaiDichVu, DonGia, MoTa, TrangThai)
                VALUES(@TenDichVu, @MaLoaiDichVu, @DonGia, @MoTa, @TrangThai)";

            SqlParameter[] param =
            {
                new SqlParameter("@TenDichVu", tenDichVu),
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@MoTa", moTa),
                new SqlParameter("@TrangThai", trangThai)
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

        public bool SuaDichVu(int maDichVu, string tenDichVu, int maLoaiDichVu, decimal donGia, string moTa, string trangThai)
        {
            string query = @"
                UPDATE DichVu
                SET TenDichVu = @TenDichVu,
                    MaLoaiDichVu = @MaLoaiDichVu,
                    DonGia = @DonGia,
                    MoTa = @MoTa,
                    TrangThai = @TrangThai
                WHERE MaDichVu = @MaDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@TenDichVu", tenDichVu),
                new SqlParameter("@MaLoaiDichVu", maLoaiDichVu),
                new SqlParameter("@DonGia", donGia),
                new SqlParameter("@MoTa", moTa),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaDichVu", maDichVu)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        public bool XoaDichVu(int maDichVu)
        {
            string query = "DELETE FROM DichVu WHERE MaDichVu = @MaDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDichVu", maDichVu)
            };

            return db.ExecuteNonQuery(query, param) > 0;
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