using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for Thống Kê (Statistics)
    /// Handles all database operations for statistical reports
    /// </summary>
    public class ThongKeDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Get total revenue by date range
        /// </summary>
        public DataTable GetRevenueByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT 
                        CONVERT(DATE, NgayThanhToan) as NgayThanhToan,
                        COUNT(*) as SoLuongGiaoDich,
                        SUM(ThanhTien) as DoanhThu
                    FROM DatDichVu
                    WHERE NgayThanhToan >= @fromDate 
                        AND NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    GROUP BY CONVERT(DATE, NgayThanhToan)
                    ORDER BY NgayThanhToan ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy doanh thu theo ngày: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get revenue by service type
        /// </summary>
        public DataTable GetRevenueByService(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT 
                        dv.TenDichVu as TenDichVu,
                        COUNT(ddv.MaDatDichVu) as SoLanSuDung,
                        SUM(ddv.ThanhTien) as DoanhThu
                    FROM DatDichVu ddv
                    INNER JOIN DichVu dv ON ddv.MaDichVu = dv.MaDichVu
                    WHERE ddv.NgayThanhToan >= @fromDate 
                        AND ddv.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    GROUP BY dv.TenDichVu
                    ORDER BY DoanhThu DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy doanh thu theo dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get total revenue amount
        /// </summary>
        public decimal GetTotalRevenue(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT ISNULL(SUM(ThanhTien), 0) as TotalRevenue
                    FROM DatDichVu
                    WHERE NgayThanhToan >= @fromDate 
                        AND NgayThanhToan < DATEADD(DAY, 1, @toDate)";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                DataTable dt = db.ExecuteQuery(sql, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["TotalRevenue"]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy tổng doanh thu: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Get booking statistics by date range
        /// </summary>
        public DataTable GetBookingStatistics(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT 
                        CONVERT(DATE, NgayNhanPhong) as NgayNhanPhong,
                        COUNT(*) as SoPhongDat,
                        COUNT(DISTINCT MaKhachHang) as SoKhachHang
                    FROM DatPhong
                    WHERE NgayNhanPhong >= @fromDate 
                        AND NgayNhanPhong < DATEADD(DAY, 1, @toDate)
                    GROUP BY CONVERT(DATE, NgayNhanPhong)
                    ORDER BY NgayNhanPhong ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thống kê đặt phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get monthly revenue statistics
        /// </summary>
        public DataTable GetMonthlyRevenue(int year)
        {
            try
            {
                string sql = @"
                    SELECT 
                        MONTH(NgayThanhToan) as Thang,
                        SUM(ThanhTien) as DoanhThu
                    FROM DatDichVu
                    WHERE YEAR(NgayThanhToan) = @year
                    GROUP BY MONTH(NgayThanhToan)
                    ORDER BY MONTH(NgayThanhToan) ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@year", year)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy doanh thu theo tháng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get service usage count by customer
        /// </summary>
        public DataTable GetServiceUsageByCustomer(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT TOP 10
                        kh.TenKhachHang as KhachHang,
                        COUNT(ddv.MaDatDichVu) as SoLanSuDung,
                        SUM(ddv.ThanhTien) as TongChiTieu
                    FROM DatDichVu ddv
                    INNER JOIN KhachHang kh ON ddv.MaKhachHang = kh.MaKhachHang
                    WHERE ddv.NgayThanhToan >= @fromDate 
                        AND ddv.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    GROUP BY kh.TenKhachHang
                    ORDER BY TongChiTieu DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thống kê khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}
