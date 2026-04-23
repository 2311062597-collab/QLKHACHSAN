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
        /// Validate date range
        /// </summary>
        private bool ValidateDateRange(DateTime fromDate, DateTime toDate, bool showMessage = true)
        {
            if (fromDate > toDate)
            {
                if (showMessage)
                    System.Windows.Forms.MessageBox.Show(
                        "Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Cảnh báo",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (toDate > DateTime.Now.Date)
            {
                if (showMessage)
                    System.Windows.Forms.MessageBox.Show(
                        "Ngày kết thúc không được lớn hơn ngày hôm nay!", "Cảnh báo",
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get revenue statistics by date range with validation
        /// </summary>
        public DataTable GetRevenueByDateRange(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (!ValidateDateRange(fromDate, toDate))
            {
                return new DataTable();
            }

            try
            {
                return dal.GetRevenueByDateRange(fromDate, toDate);
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
            // Validate date range
            if (!ValidateDateRange(fromDate, toDate))
            {
                return new DataTable();
            }

            try
            {
                return dal.GetRevenueByService(fromDate, toDate);
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
            // Validate date range (no message for this one)
            if (!ValidateDateRange(fromDate, toDate, false))
            {
                return 0;
            }

            try
            {
                return dal.GetTotalRevenue(fromDate, toDate);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy tổng doanh thu: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Get booking statistics
        /// </summary>
        public DataTable GetBookingStatistics(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (!ValidateDateRange(fromDate, toDate))
            {
                return new DataTable();
            }

            try
            {
                return dal.GetBookingStatistics(fromDate, toDate);
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
            // Validate year
            if (year < 2000 || year > DateTime.Now.Year)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Năm không hợp lệ! Vui lòng chọn năm từ 2000 đến " + DateTime.Now.Year + ".", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return new DataTable();
            }

            try
            {
                return dal.GetMonthlyRevenue(year);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy doanh thu theo tháng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get service usage by customer
        /// </summary>
        public DataTable GetServiceUsageByCustomer(DateTime fromDate, DateTime toDate)
        {
            // Validate date range
            if (!ValidateDateRange(fromDate, toDate))
            {
                return new DataTable();
            }

            try
            {
                return dal.GetServiceUsageByCustomer(fromDate, toDate);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thống kê khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
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
