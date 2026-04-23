using System;
using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    /// <summary>
    /// Business Logic Layer for Đặt Phòng (Room Booking)
    /// Handles validation and business rules for room bookings
    /// </summary>
    public class DatPhongBLL
    {
        private DatPhongDAL dal = new DatPhongDAL();

        /// <summary>
        /// Get all rooms
        /// </summary>
        public DataTable GetAllRooms()
        {
            return dal.GetAllRooms();
        }

        /// <summary>
        /// Get rooms by type
        /// </summary>
        public DataTable GetRoomsByType(int roomTypeId)
        {
            return dal.GetRoomsByType(roomTypeId);
        }

        /// <summary>
        /// Validate room availability
        /// </summary>
        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            // Validate dates
            if (checkIn >= checkOut)
            {
                System.Windows.Forms.MessageBox.Show("Ngày nhận phải nhỏ hơn ngày trả!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (checkIn < DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show("Ngày nhận không được nhỏ hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return dal.IsRoomAvailable(roomId, checkIn, checkOut);
        }

        /// <summary>
        /// Get customer by phone with validation
        /// </summary>
        public DataTable GetCustomerByPhone(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return new DataTable();

            return dal.GetCustomerByPhone(phoneNumber);
        }

        /// <summary>
        /// Get customer by identity number with validation
        /// </summary>
        public DataTable GetCustomerByIdentity(string identityNumber)
        {
            if (string.IsNullOrWhiteSpace(identityNumber))
                return new DataTable();

            return dal.GetCustomerByIdentity(identityNumber);
        }

        /// <summary>
        /// Get all room types
        /// </summary>
        public DataTable GetAllRoomTypes()
        {
            return dal.GetAllRoomTypes();
        }

        /// <summary>
        /// Get service add-ons
        /// </summary>
        public DataTable GetAddOnServices()
        {
            return dal.GetAddOnServices();
        }

        /// <summary>
        /// Calculate total price for booking
        /// </summary>
        public decimal CalculateTotalPrice(int roomId, DateTime checkIn, DateTime checkOut, decimal serviceAmount)
        {
            decimal roomPrice = dal.GetRoomPrice(roomId);
            int days = (checkOut.Date - checkIn.Date).Days;
            if (days == 0) days = 1;

            decimal totalPrice = (roomPrice * days) + serviceAmount;
            return totalPrice;
        }

        /// <summary>
        /// Apply discount to total
        /// </summary>
        public decimal ApplyDiscount(decimal totalPrice, int discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
                return totalPrice;

            decimal discountAmount = (totalPrice * discountPercent) / 100;
            return totalPrice - discountAmount;
        }

        /// <summary>
        /// Validate booking information
        /// </summary>
        public bool ValidateBookingData(string customerName, string roomName, DateTime checkIn, DateTime checkOut)
        {
            if (string.IsNullOrWhiteSpace(customerName))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(roomName))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (checkIn >= checkOut)
            {
                System.Windows.Forms.MessageBox.Show("Ngày nhận phải nhỏ hơn ngày trả!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Create new booking
        /// </summary>
        public int CreateBooking(int roomId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            // Validate
            if (!IsRoomAvailable(roomId, checkIn, checkOut))
            {
                System.Windows.Forms.MessageBox.Show("Phòng không khả dụng trong khoảng thời gian này!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return 0;
            }

            return dal.CreateBooking(roomId, customerId, checkIn, checkOut);
        }

        /// <summary>
        /// Add service to booking
        /// </summary>
        public bool AddServiceToBooking(int bookingId, int serviceId, decimal price)
        {
            if (bookingId <= 0 || serviceId <= 0 || price < 0)
                return false;

            return dal.AddServiceToBooking(bookingId, serviceId, price);
        }

        /// <summary>
        /// Get booking details
        /// </summary>
        public DataTable GetBookingDetails(int bookingId)
        {
            if (bookingId <= 0)
                return new DataTable();

            return dal.GetBookingDetails(bookingId);
        }

        /// <summary>
        /// Complete booking
        /// </summary>
        public bool CompleteBooking(int bookingId, DateTime checkOutDate)
        {
            if (bookingId <= 0)
                return false;

            return dal.CompleteBooking(bookingId, checkOutDate);
        }

        /// <summary>
        /// Get room details
        /// </summary>
        public DataTable GetRoomDetails(int roomId)
        {
            if (roomId <= 0)
                return new DataTable();

            return dal.GetRoomDetails(roomId);
        }

        /// <summary>
        /// Format currency value
        /// </summary>
        public string FormatCurrency(decimal value)
        {
            return value.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }

        /// <summary>
        /// Get status color for room display
        /// </summary>
        public System.Drawing.Color GetRoomStatusColor(string status)
        {
            if (status == "Trống")
                return System.Drawing.Color.LimeGreen;
            if (status == "Đã đặt")
                return System.Drawing.Color.Orange;
            if (status == "Đang sử dụng")
                return System.Drawing.Color.Red;
            return System.Drawing.Color.Gray;
        }

        /// <summary>
        /// Calculate total service amount from data table
        /// </summary>
        public decimal GetTotalServiceAmount(DataTable dtServices)
        {
            return dal.GetTotalServiceAmount(dtServices);
        }

        /// <summary>
        /// Validate checkout date
        /// </summary>
        public bool ValidateCheckoutDate(DateTime checkOut, DateTime checkIn)
        {
            if (checkOut <= checkIn)
            {
                System.Windows.Forms.MessageBox.Show("Ngày trả phải lớn hơn ngày nhận!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate checkin date
        /// </summary>
        public bool ValidateCheckinDate(DateTime checkIn)
        {
            if (checkIn < DateTime.Now.Date)
            {
                System.Windows.Forms.MessageBox.Show("Ngày nhận không được nhỏ hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate customer selection
        /// </summary>
        public bool ValidateCustomerSelected(int customerId)
        {
            if (customerId <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate room selection
        /// </summary>
        public bool ValidateRoomSelected(int roomId)
        {
            if (roomId <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
