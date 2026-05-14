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
                        CONVERT(DATE, ttt.NgayThanhToan) as NgayThanhToan,
                        COUNT(*) as SoLuongGiaoDich,
                        SUM(ttt.SoTien) as DoanhThu
                    FROM ThanhToanDatPhong ttt
                    WHERE ttt.NgayThanhToan >= @fromDate 
                        AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    GROUP BY CONVERT(DATE, ttt.NgayThanhToan)
                    ORDER BY NgayThanhToan ASC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetRevenueByDateRange from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetRevenueByDateRange: {ex.Message}");
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
                TenDichVu,
                SUM(SoLanSuDung) as SoLanSuDung,
                SUM(DoanhThu) as DoanhThu
            FROM
            (
                SELECT 
                    N'Phòng' as TenDichVu,
                    COUNT(DISTINCT dp.MaDatPhong) as SoLanSuDung,
                    SUM(ttt.SoTien) as DoanhThu
                FROM ThanhToanDatPhong ttt
                INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
                WHERE ttt.NgayThanhToan >= @fromDate 
                    AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)

                UNION ALL

                SELECT 
                    dv.TenDichVu as TenDichVu,
                    COUNT(ddv.MaDatDichVu) as SoLanSuDung,
                    SUM(ddv.ThanhTien) as DoanhThu
                FROM DatDichVu ddv
                INNER JOIN DichVu dv ON ddv.MaDichVu = dv.MaDichVu
                WHERE ddv.NgayThanhToan >= @fromDate 
                    AND ddv.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                GROUP BY dv.TenDichVu
            ) AS BangDoanhThu
            GROUP BY TenDichVu
            ORDER BY DoanhThu DESC";

                SqlParameter[] parameters = {
            new SqlParameter("@fromDate", fromDate),
            new SqlParameter("@toDate", toDate)
        };

                DataTable result = db.ExecuteQuery(sql, parameters);
                return result;
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
            SELECT ISNULL(SUM(DoanhThu), 0) as TotalRevenue
            FROM
            (
                SELECT 
                    SUM(ttt.SoTien) as DoanhThu
                FROM ThanhToanDatPhong ttt
                WHERE ttt.NgayThanhToan >= @fromDate 
                    AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)

                UNION ALL

                SELECT 
                    SUM(ddv.ThanhTien) as DoanhThu
                FROM DatDichVu ddv
                WHERE ddv.NgayThanhToan >= @fromDate 
                    AND ddv.NgayThanhToan < DATEADD(DAY, 1, @toDate)
            ) AS BangTongDoanhThu";

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

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetBookingStatistics from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetBookingStatistics: {ex.Message}");
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
                Thang,
                SUM(DoanhThu) as DoanhThu
            FROM
            (
                SELECT 
                    MONTH(ttt.NgayThanhToan) as Thang,
                    SUM(ttt.SoTien) as DoanhThu
                FROM ThanhToanDatPhong ttt
                WHERE YEAR(ttt.NgayThanhToan) = @year
                GROUP BY MONTH(ttt.NgayThanhToan)

                UNION ALL

                SELECT 
                    MONTH(ddv.NgayThanhToan) as Thang,
                    SUM(ddv.ThanhTien) as DoanhThu
                FROM DatDichVu ddv
                WHERE YEAR(ddv.NgayThanhToan) = @year
                GROUP BY MONTH(ddv.NgayThanhToan)
            ) AS BangDoanhThuThang
            GROUP BY Thang
            ORDER BY Thang ASC";

                SqlParameter[] parameters = {
            new SqlParameter("@year", year)
        };

                DataTable result = db.ExecuteQuery(sql, parameters);
                return result;
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
                        kh.HoTen as KhachHang,
                        COUNT(DISTINCT ttt.MaDatPhong) as SoLanSuDung,
                        SUM(ttt.SoTien) as TongChiTieu
                    FROM ThanhToanDatPhong ttt
                    INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    WHERE ttt.NgayThanhToan >= @fromDate 
                        AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    GROUP BY kh.HoTen
                    ORDER BY TongChiTieu DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetServiceUsageByCustomer from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetServiceUsageByCustomer: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thống kê khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get detailed transaction data by date range
        /// </summary>
        public DataTable GetDetailedRevenueByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT 
                        ttt.MaThanhToan,
                        ttt.MaDatPhong,
                        ttt.MaPhuongThuc,
                        ttt.SoTien as DoanhThu,
                        CONVERT(DATE, ttt.NgayThanhToan) as NgayThanhToan,
                        ttt.TrangThai,
                        dp.NgayNhanPhong,
                        dp.NgayTraPhong,
                        kh.HoTen as TenKhachHang
                    FROM ThanhToanDatPhong ttt
                    INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    WHERE ttt.NgayThanhToan >= @fromDate 
                        AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    ORDER BY ttt.NgayThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetDetailedRevenueByDateRange from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetDetailedRevenueByDateRange: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết doanh thu: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get detailed transaction data for all transactions (no aggregation)
        /// Includes both room bookings and service invoices in one table
        /// </summary>
        public DataTable GetAllDetailedTransactions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
    -- Hóa đơn đặt phòng
    SELECT 
        'PHÒNG' as LoaiGiaoDich,
        ttt.MaDatPhong as MaHoaDon,
        kh.HoTen as TenKhachHang,
        'Phòng' as TenChiTieu,
        ttt.SoTien as DoanhThu,
        CONVERT(VARCHAR(10), ttt.NgayThanhToan, 23) as NgayThanhToan,
        pt.TenPhuongThuc as PhuongThuc
    FROM ThanhToanDatPhong ttt
    INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
    LEFT JOIN PhuongThucThanhToan pt ON ttt.MaPhuongThuc = pt.MaPhuongThuc
    WHERE ttt.NgayThanhToan >= @fromDate 
        AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)

    UNION ALL

    -- Hóa đơn dịch vụ
    SELECT 
        N'DỊCH VỤ' as LoaiGiaoDich,
        dp.MaDatPhong as MaHoaDon,
        kh.HoTen as TenKhachHang,
        dvu.TenDichVu as TenChiTieu,
        dv.ThanhTien as DoanhThu,
        CONVERT(VARCHAR(10), dv.NgayThanhToan, 23) as NgayThanhToan,
        pt.TenPhuongThuc as PhuongThuc
    FROM DatDichVu dv
    INNER JOIN KhachHang kh ON dv.MaKhachHang = kh.MaKhachHang
    INNER JOIN DichVu dvu ON dv.MaDichVu = dvu.MaDichVu
    LEFT JOIN PhuongThucThanhToan pt ON dv.MaPhuongThuc = pt.MaPhuongThuc
    LEFT JOIN DatPhong dp ON dv.MaDatDichVu = dp.MaDatPhong
    WHERE dv.NgayThanhToan >= @fromDate 
        AND dv.NgayThanhToan < DATEADD(DAY, 1, @toDate)

    ORDER BY NgayThanhToan DESC, MaHoaDon DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetAllDetailedTransactions (MERGED) from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetAllDetailedTransactions: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết giao dịch: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();

            }
        }

        /// <summary>
        /// Get detailed transactions for top customers
        /// </summary>
        public DataTable GetDetailedCustomerTransactions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string sql = @"
                    SELECT TOP 100
                        ttt.MaThanhToan,
                        ttt.MaDatPhong,
                        kh.HoTen as TenKhachHang,
                        ttt.MaPhuongThuc,
                        ttt.SoTien as DoanhThu,
                        CONVERT(VARCHAR(10), ttt.NgayThanhToan, 23) as NgayThanhToan,
                        ttt.TrangThai
                    FROM ThanhToanDatPhong ttt
                    INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    WHERE ttt.NgayThanhToan >= @fromDate 
                        AND ttt.NgayThanhToan < DATEADD(DAY, 1, @toDate)
                    ORDER BY ttt.SoTien DESC, ttt.NgayThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@fromDate", fromDate),
                    new SqlParameter("@toDate", toDate)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetDetailedCustomerTransactions from {fromDate:yyyy-MM-dd} to {toDate:yyyy-MM-dd}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetDetailedCustomerTransactions: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết giao dịch khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get detailed transactions for the year
        /// </summary>
        public DataTable GetDetailedYearlyTransactions(int year)
        {
            try
            {
                string sql = @"
                    SELECT 
                        ttt.MaThanhToan,
                        ttt.MaDatPhong,
                        kh.HoTen as TenKhachHang,
                        ttt.MaPhuongThuc,
                        ttt.SoTien as DoanhThu,
                        CONVERT(VARCHAR(10), ttt.NgayThanhToan, 23) as NgayThanhToan,
                        ttt.TrangThai
                    FROM ThanhToanDatPhong ttt
                    INNER JOIN DatPhong dp ON ttt.MaDatPhong = dp.MaDatPhong
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    WHERE YEAR(ttt.NgayThanhToan) = @year
                    ORDER BY ttt.NgayThanhToan DESC, ttt.MaThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@year", year)
                };

                System.Diagnostics.Debug.WriteLine($"Executing SQL: GetDetailedYearlyTransactions for year {year}");
                DataTable result = db.ExecuteQuery(sql, parameters);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetDetailedYearlyTransactions: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết giao dịch hàng năm: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get employee information
        /// </summary>
        public DataTable GetEmployeeInfo()
        {
            try
            {
                string sql = @"
                    SELECT TOP (1000) 
                        [NhanVienID],
                        [HoTen],
                        [SoDienThoai],
                        [SoKhachHang],
                        [CCCD],
                        [DiaChiChiTiet],
                        [MaTaiKhoan],
                        [GioiTinh]
                    FROM [QuanLyKhachSan].[dbo].[NhanVien]";

                System.Diagnostics.Debug.WriteLine("Executing SQL: GetEmployeeInfo");
                DataTable result = db.ExecuteQuery(sql, null);
                System.Diagnostics.Debug.WriteLine($"Query returned {result?.Rows.Count ?? 0} rows");
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SQL Error in GetEmployeeInfo: {ex.Message}");
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin nhân viên: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}
