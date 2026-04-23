using System;
using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    /// <summary>
    /// Business Logic Layer for Thống Kê (Statistics)
    /// Handles validation and business rules for statistical reports
    /// </summary>
    public class ThongKeBLL
    {
        private ThongKeDAL dal = new ThongKeDAL();

        /// <summary>
        /// Get revenue statistics by date range with validation
        /// </summary>
        public DataTable GetRevenueByDateRange(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (fromDate > toDate)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            // Validate date not in future
            if (toDate > DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            return dal.GetRevenueByDateRange(fromDate, toDate);
        }

        /// <summary>
        /// Get revenue by service type
        /// </summary>
        public DataTable GetRevenueByService(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (fromDate > toDate)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            if (toDate > DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            return dal.GetRevenueByService(fromDate, toDate);
        }

        /// <summary>
        /// Get total revenue amount
        /// </summary>
        public decimal GetTotalRevenue(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (fromDate > toDate)
            {
                return 0;
            }

            if (toDate > DateTime.Now.Date)
            {
                return 0;
            }

            return dal.GetTotalRevenue(fromDate, toDate);
        }

        /// <summary>
        /// Get booking statistics
        /// </summary>
        public DataTable GetBookingStatistics(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (fromDate > toDate)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            if (toDate > DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            return dal.GetBookingStatistics(fromDate, toDate);
        }

        /// <summary>
        /// Get monthly revenue statistics
        /// </summary>
        public DataTable GetMonthlyRevenue(int year)
        {
            // Validate year
            if (year < 2000 || year > DateTime.Now.Year)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Năm không hợp lệ! Vui lòng chọn năm từ 2000 đến hiện tại.", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            return dal.GetMonthlyRevenue(year);
        }

        /// <summary>
        /// Get service usage by customer
        /// </summary>
        public DataTable GetServiceUsageByCustomer(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (fromDate > toDate)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            if (toDate > DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            return dal.GetServiceUsageByCustomer(fromDate, toDate);
        }

        /// <summary>
        /// Format currency value to Vietnamese format
        /// </summary>
        public string FormatCurrency(decimal value)
        {
            return value.ToString("N0") + " đ";
        }

        /// <summary>
        /// Get month name from month number
        /// </summary>
        public string GetMonthName(int month)
        {
            switch (month)
            {
                case 1: return "Tháng 1";
                case 2: return "Tháng 2";
                case 3: return "Tháng 3";
                case 4: return "Tháng 4";
                case 5: return "Tháng 5";
                case 6: return "Tháng 6";
                case 7: return "Tháng 7";
                case 8: return "Tháng 8";
                case 9: return "Tháng 9";
                case 10: return "Tháng 10";
                case 11: return "Tháng 11";
                case 12: return "Tháng 12";
                default: return "Không xác định";
            }
        }
    }
}
