using System;
using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    /// <summary>
    /// Business Logic Layer for Thanh Toán (Payment)
    /// Handles payment processing and validation
    /// </summary>
    public class ThanhToanBLL
    {
        private ThanhToanDAL dal = new ThanhToanDAL();
        private DatPhongDAL datPhongDAL = new DatPhongDAL();

        /// <summary>
        /// Get booking info by room ID (for booked rooms)
        /// </summary>
        public DataTable GetBookingByRoomId(int roomId)
        {
            if (roomId <= 0)
                return new DataTable();
            return dal.GetBookingByRoomId(roomId);
        }

        /// <summary>
        /// Get full booking details
        /// </summary>
        public DataTable GetBookingDetails(int bookingId)
        {
            if (bookingId <= 0)
                return new DataTable();
            return dal.GetBookingDetails(bookingId);
        }

        /// <summary>
        /// Get all services for a booking
        /// </summary>
        public DataTable GetBookingServices(int bookingId)
        {
            if (bookingId <= 0)
                return new DataTable();
            return dal.GetBookingServices(bookingId);
        }

        /// <summary>
        /// Calculate total amount for booking
        /// </summary>
        public decimal CalculateTotalAmount(int bookingId)
        {
            if (bookingId <= 0)
                return 0;
            return dal.CalculateTotalAmount(bookingId);
        }

        /// <summary>
        /// Get payment info if already exists
        /// </summary>
        public DataTable GetPaymentInfo(int bookingId)
        {
            if (bookingId <= 0)
                return new DataTable();
            return dal.GetPaymentInfo(bookingId);
        }

        /// <summary>
        /// Validate payment amount
        /// </summary>
        public bool ValidatePaymentAmount(decimal paymentAmount, decimal totalAmount)
        {
            if (paymentAmount < totalAmount)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"Số tiền thanh toán ({FormatCurrency(paymentAmount)}) không đủ!\nTổng tiền: {FormatCurrency(totalAmount)}", 
                    "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, 
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Calculate change amount
        /// </summary>
        public decimal CalculateChange(decimal paymentAmount, decimal totalAmount)
        {
            if (paymentAmount < totalAmount)
                return 0;
            return paymentAmount - totalAmount;
        }

        /// <summary>
        /// Format currency
        /// </summary>
        public string FormatCurrency(decimal value)
        {
            return value.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }

        /// <summary>
        /// Get payment methods
        /// </summary>
        public string[] GetPaymentMethods()
        {
            return new string[] { "Tiền mặt", "Thẻ tín dụng", "Chuyển khoản ngân hàng", "E-wallet" };
        }

        /// <summary>
        /// Process payment
        /// </summary>
        public int ProcessPayment(int bookingId, decimal amount, string paymentMethod, string notes = "")
        {
            if (bookingId <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Mã booking không hợp lệ!", "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }

            return datPhongDAL.RecordPayment(bookingId, amount, paymentMethod, notes);
        }

        /// <summary>
        /// Check if payment already completed
        /// </summary>
        public bool IsPaymentCompleted(int bookingId)
        {
            try
            {
                DataTable dt = GetPaymentInfo(bookingId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string status = dt.Rows[0]["TrangThaiThanhToan"].ToString();
                    return status == "Đã thanh toán";
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get number of nights
        /// </summary>
        public int GetNumberOfNights(int bookingId)
        {
            try
            {
                DataTable dt = GetBookingDetails(bookingId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DateTime checkIn = Convert.ToDateTime(dt.Rows[0]["NgayNhan"]);
                    DateTime checkOut = Convert.ToDateTime(dt.Rows[0]["NgayTra"]);
                    int nights = (checkOut.Date - checkIn.Date).Days;
                    return nights > 0 ? nights : 1;
                }
            }
            catch { }
            return 1;
        }

        /// <summary>
        /// Generate invoice details
        /// </summary>
        public DataTable GenerateInvoiceDetails(int bookingId)
        {
            try
            {
                DataTable dtInvoice = new DataTable();
                dtInvoice.Columns.Add("HạngMục", typeof(string));
                dtInvoice.Columns.Add("SoLuong", typeof(int));
                dtInvoice.Columns.Add("DonGia", typeof(decimal));
                dtInvoice.Columns.Add("ThanhTien", typeof(decimal));

                DataTable dtBooking = GetBookingDetails(bookingId);
                if (dtBooking == null || dtBooking.Rows.Count == 0)
                    return dtInvoice;

                DataRow bookingRow = dtBooking.Rows[0];
                decimal roomPrice = Convert.ToDecimal(bookingRow["Gia"]);
                int nights = GetNumberOfNights(bookingId);
                decimal roomTotal = roomPrice * nights;

                // Add room row
                DataRow drRoom = dtInvoice.NewRow();
                drRoom["HạngMục"] = $"Phòng {bookingRow["SoPhong"]} ({bookingRow["TenLoaiPhong"]})";
                drRoom["SoLuong"] = nights;
                drRoom["DonGia"] = roomPrice;
                drRoom["ThanhTien"] = roomTotal;
                dtInvoice.Rows.Add(drRoom);

                // Add services
                DataTable dtServices = GetBookingServices(bookingId);
                if (dtServices != null && dtServices.Rows.Count > 0)
                {
                    foreach (DataRow serviceRow in dtServices.Rows)
                    {
                        DataRow drService = dtInvoice.NewRow();
                        drService["HạngMục"] = serviceRow["TenDichVu"].ToString();
                        drService["SoLuong"] = 1;
                        drService["DonGia"] = Convert.ToDecimal(serviceRow["ThanhTien"]);
                        drService["ThanhTien"] = Convert.ToDecimal(serviceRow["ThanhTien"]);
                        dtInvoice.Rows.Add(drService);
                    }
                }

                return dtInvoice;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tạo hóa đơn: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Update booking status to "Đang sử dụng" when payment completed
        /// </summary>
        public bool UpdateBookingStatusToInUse(int bookingId)
        {
            try
            {
                return dal.UpdateBookingStatus(bookingId, "Đang sử dụng");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update room status
        /// </summary>
        public bool UpdateRoomStatus(int roomId, string status)
        {
            try
            {
                return dal.UpdateRoomStatus(roomId, status);
            }
            catch
            {
                return false;
            }
        }
    }
}
