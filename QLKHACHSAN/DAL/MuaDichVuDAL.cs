using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for MuaDichVu (Service Purchase)
    /// Handles database operations for service purchases
    /// </summary>
    public class MuaDichVuDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Get all service purchases
        /// </summary>
        public DataTable GetAll()
        {
            string query = @"
                SELECT 
                    MaDatDichVu,
                    MaKhachHang,
                    MaNhanVien,
                    MaDichVu,
                    SoLuong,
                    ThanhTien,
                    MaPhuongThuc,
                    NgayThanhToan
                FROM DatDichVu
                ORDER BY NgayThanhToan DESC";

            return db.ExecuteQuery(query);
        }

        /// <summary>
        /// Get service purchase by ID
        /// </summary>
        public DataTable GetById(string maDatDichVu)
        {
            string query = @"
                SELECT 
                    MaDatDichVu,
                    MaKhachHang,
                    MaNhanVien,
                    MaDichVu,
                    SoLuong,
                    ThanhTien,
                    MaPhuongThuc,
                    NgayThanhToan
                FROM DatDichVu
                WHERE MaDatDichVu = @MaDatDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatDichVu", maDatDichVu)
            };

            return db.ExecuteQuery(query, param);
        }

        /// <summary>
        /// Insert new service purchase
        /// </summary>
        public bool Insert(string maKhachHang, string maNhanVien, string maDichVu,
                          int soLuong, decimal thanhTien, string maPhuongThuc, DateTime ngayThanhToan)
        {
            string query = @"
                INSERT INTO DatDichVu(
                    MaKhachHang,
                    MaNhanVien,
                    MaDichVu,
                    SoLuong,
                    ThanhTien,
                    MaPhuongThuc,
                    NgayThanhToan)
                VALUES(
                    @MaKhachHang,
                    @MaNhanVien,
                    @MaDichVu,
                    @SoLuong,
                    @ThanhTien,
                    @MaPhuongThuc,
                    @NgayThanhToan)";

            SqlParameter[] param =
            {
                new SqlParameter("@MaKhachHang", maKhachHang),
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@MaDichVu", maDichVu),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@ThanhTien", thanhTien),
                new SqlParameter("@MaPhuongThuc", maPhuongThuc),
                new SqlParameter("@NgayThanhToan", ngayThanhToan)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        /// <summary>
        /// Update existing service purchase
        /// </summary>
        public bool Update(string maDatDichVu, string maKhachHang, string maNhanVien, string maDichVu,
                          int soLuong, decimal thanhTien, string maPhuongThuc, DateTime ngayThanhToan)
        {
            string query = @"
                UPDATE DatDichVu
                SET MaKhachHang = @MaKhachHang,
                    MaNhanVien = @MaNhanVien,
                    MaDichVu = @MaDichVu,
                    SoLuong = @SoLuong,
                    ThanhTien = @ThanhTien,
                    MaPhuongThuc = @MaPhuongThuc,
                    NgayThanhToan = @NgayThanhToan
                WHERE MaDatDichVu = @MaDatDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatDichVu", maDatDichVu),
                new SqlParameter("@MaKhachHang", maKhachHang),
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@MaDichVu", maDichVu),
                new SqlParameter("@SoLuong", soLuong),
                new SqlParameter("@ThanhTien", thanhTien),
                new SqlParameter("@MaPhuongThuc", maPhuongThuc),
                new SqlParameter("@NgayThanhToan", ngayThanhToan)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        /// <summary>
        /// Delete service purchase
        /// </summary>
        public bool Delete(string maDatDichVu)
        {
            string query = "DELETE FROM DatDichVu WHERE MaDatDichVu = @MaDatDichVu";

            SqlParameter[] param =
            {
                new SqlParameter("@MaDatDichVu", maDatDichVu)
            };

            return db.ExecuteNonQuery(query, param) > 0;
        }

        /// <summary>
        /// Search service purchases by customer ID
        /// </summary>
        public DataTable SearchByCustomer(string maKhachHang)
        {
            string query = @"
                SELECT 
                    MaDatDichVu,
                    MaKhachHang,
                    MaNhanVien,
                    MaDichVu,
                    SoLuong,
                    ThanhTien,
                    MaPhuongThuc,
                    NgayThanhToan
                FROM DatDichVu
                WHERE MaKhachHang = @MaKhachHang
                ORDER BY NgayThanhToan DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@MaKhachHang", maKhachHang)
            };

            return db.ExecuteQuery(query, param);
        }

        /// <summary>
        /// Get service purchases by employee ID
        /// </summary>
        public DataTable GetByEmployeeId(string maNhanVien)
        {
            string query = @"
                SELECT 
                    MaDatDichVu,
                    MaKhachHang,
                    MaNhanVien,
                    MaDichVu,
                    SoLuong,
                    ThanhTien,
                    MaPhuongThuc,
                    NgayThanhToan
                FROM DatDichVu
                WHERE MaNhanVien = @MaNhanVien
                ORDER BY NgayThanhToan DESC";

            SqlParameter[] param =
            {
                new SqlParameter("@MaNhanVien", maNhanVien)
            };

            return db.ExecuteQuery(query, param);
        }

        /// <summary>
        /// Get total revenue from service purchases
        /// </summary>
        public decimal GetTotalRevenue()
        {
            string query = "SELECT ISNULL(SUM(ThanhTien), 0) FROM DatDichVu";
            object result = db.ExecuteScalar(query);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Get total revenue from service purchases by date range
        /// </summary>
        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT ISNULL(SUM(ThanhTien), 0) 
                FROM DatDichVu
                WHERE NgayThanhToan BETWEEN @StartDate AND @EndDate";

            SqlParameter[] param =
            {
                new SqlParameter("@StartDate", startDate),
                new SqlParameter("@EndDate", endDate)
            };

            object result = db.ExecuteScalar(query, param);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
    }
}
