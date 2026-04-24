using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for Đặt Phòng (Room Booking)
    /// Handles all database operations for room bookings
    /// </summary>
    public class DatPhongDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Get all rooms with their current status
        /// </summary>
        public DataTable GetAllRooms()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong as TenPhong,
                        lp.TenLoaiPhong,
                        p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    ORDER BY p.SoPhong";

                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy danh sách phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get rooms by type
        /// </summary>
        public DataTable GetRoomsByType(int roomTypeId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong as TenPhong,
                        lp.TenLoaiPhong,
                        p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaLoaiPhong = @roomTypeId
                    ORDER BY p.SoPhong";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomTypeId", roomTypeId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy phòng theo loại: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Check if room is available for booking
        /// </summary>
        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                // First check if room status is "Trống" (available)
                string statusQuery = @"
                    SELECT TrangThai
                    FROM Phong
                    WHERE MaPhong = @roomId";

                SqlParameter[] statusParams = {
                    new SqlParameter("@roomId", roomId)
                };

                DataTable dtStatus = db.ExecuteQuery(statusQuery, statusParams);
                if (dtStatus.Rows.Count == 0)
                {
                    return false;
                }

                // Check if there are any overlapping bookings in the requested date range
                // Only check non-completed bookings
                string bookingQuery = @"
                    SELECT COUNT(*) as BookingCount
                    FROM DatPhong
                    WHERE MaPhong = @roomId
                    AND NgayNhan < @checkOut
                    AND NgayTra > @checkIn
                    AND (TrangThai = N'Chờ xử lý' OR TrangThai = N'Đã xác nhận' OR TrangThai = N'Đang sử dụng')";

                SqlParameter[] bookingParams = {
                    new SqlParameter("@roomId", roomId),
                    new SqlParameter("@checkIn", checkIn.Date),
                    new SqlParameter("@checkOut", checkOut.Date)
                };

                DataTable dtBooking = db.ExecuteQuery(bookingQuery, bookingParams);
                if (dtBooking.Rows.Count > 0)
                {
                    int bookingCount = Convert.ToInt32(dtBooking.Rows[0]["BookingCount"]);
                    if (bookingCount > 0)
                    {
                        return false; // Room has overlapping bookings
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi kiểm tra trạng thái phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get customer by phone number
        /// </summary>
        public DataTable GetCustomerByPhone(string phoneNumber)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaKhachHang,
                        HoTen,
                        SoDienThoai,
                        CCCD
                    FROM KhachHang
                    WHERE SoDienThoai = @phone";

                SqlParameter[] parameters = {
                    new SqlParameter("@phone", phoneNumber)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get customer by identity number
        /// </summary>
        public DataTable GetCustomerByIdentity(string identityNumber)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaKhachHang,
                        HoTen,
                        SoDienThoai,
                        CCCD
                    FROM KhachHang
                    WHERE CCCD = @cccd";

                SqlParameter[] parameters = {
                    new SqlParameter("@cccd", identityNumber)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get all room types
        /// </summary>
        public DataTable GetAllRoomTypes()
        {
            try
            {
                string query = "SELECT MaLoaiPhong, TenLoaiPhong FROM LoaiPhong ORDER BY TenLoaiPhong";
                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy loại phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get service add-ons and their prices
        /// </summary>
        public DataTable GetAddOnServices()
        {
            try
            {
                string query = @"
                    SELECT 
                        MaDichVu,
                        TenDichVu,
                        DonGia as Gia
                    FROM DichVu
                    ORDER BY TenDichVu";

                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get room pricing
        /// </summary>
        public decimal GetRoomPrice(int roomId)
        {
            try
            {
                string query = @"
                    SELECT lp.Gia
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", roomId)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["Gia"]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy giá phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Create new booking by inserting into DatPhong and updating room status
        /// </summary>
        public int CreateBooking(int roomId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                // Insert booking record into DatPhong table
                // Using default employee (Admin) with MaNhanVien = 1
                string query = @"
                    INSERT INTO DatPhong (MaKhachHang, MaPhong, MaNhanVien, NgayNhan, NgayTra, TrangThai)
                    VALUES (@customerId, @roomId, 1, @checkIn, @checkOut, N'Chờ xử lý');
                    SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = {
                    new SqlParameter("@customerId", customerId),
                    new SqlParameter("@roomId", roomId),
                    new SqlParameter("@checkIn", checkIn.Date),
                    new SqlParameter("@checkOut", checkOut.Date)
                };

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        object result = cmd.ExecuteScalar();
                        int bookingId = result != null ? Convert.ToInt32(result) : 0;

                        if (bookingId > 0)
                        {
                            // Update room status to "Đã đặt" (Booked)
                            string updateQuery = @"
                                UPDATE Phong
                                SET TrangThai = N'Đã đặt'
                                WHERE MaPhong = @roomId";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@roomId", roomId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        return bookingId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tạo đặt phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Add service to booking
        /// </summary>
        public bool AddServiceToBooking(int bookingId, int serviceId, decimal price)
        {
            try
            {
                string query = @"
                    INSERT INTO DatDichVu (MaDatPhong, MaDichVu, ThanhTien, NgayThanhToan)
                    VALUES (@bookingId, @serviceId, @price, GETDATE())";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId),
                    new SqlParameter("@serviceId", serviceId),
                    new SqlParameter("@price", price)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get booking details
        /// </summary>
        public DataTable GetBookingDetails(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong as TenPhong,
                        lp.TenLoaiPhong,
                        p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết đặt phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Update booking checkout date and mark as completed
        /// </summary>
        public bool CompleteBooking(int bookingId, DateTime checkOutDate)
        {
            try
            {
                // Update room status back to "Trống" (Available)
                string query = @"
                    UPDATE Phong
                    SET TrangThai = N'Trống'
                    WHERE MaPhong = @roomId";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", bookingId)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi hoàn tất đặt phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get room details
        /// </summary>
        public DataTable GetRoomDetails(int roomId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong as TenPhong,
                        lp.MaLoaiPhong,
                        lp.TenLoaiPhong
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", roomId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get total service amount for an invoice
        /// </summary>
        public decimal GetTotalServiceAmount(DataTable dtServices)
        {
            decimal total = 0;
            if (dtServices != null)
            {
                foreach (DataRow row in dtServices.Rows)
                {
                    total += Convert.ToDecimal(row["ThanhTien"] ?? 0);
                }
            }
            return total;
        }

        /// <summary>
        /// Record payment for booking
        /// </summary>
        public int RecordPayment(int bookingId, decimal totalAmount, string paymentMethod)
        {
            try
            {
                string query = @"
                    INSERT INTO ThanhToan (MaDatPhong, SoTien, PhuongThucThanhToan, NgayThanhToan, TrangThaiThanhToan)
                    VALUES (@bookingId, @amount, @method, GETDATE(), N'Đã thanh toán')
                    SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId),
                    new SqlParameter("@amount", totalAmount),
                    new SqlParameter("@method", paymentMethod)
                };

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        object result = cmd.ExecuteScalar();
                        int paymentId = result != null ? Convert.ToInt32(result) : 0;

                        if (paymentId > 0)
                        {
                            // Update booking status to "Đã thanh toán"
                            string updateQuery = @"
                                UPDATE DatPhong
                                SET TrangThaiDatPhong = N'Đã thanh toán'
                                WHERE MaDatPhong = @bookingId";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@bookingId", bookingId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        return paymentId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi ghi nhận thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Get payment status for booking
        /// </summary>
        public string GetPaymentStatus(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT ISNULL(TrangThaiThanhToan, N'Chưa thanh toán') as PaymentStatus
                    FROM ThanhToan
                    WHERE MaDatPhong = @bookingId
                    ORDER BY MaThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["PaymentStatus"].ToString();
                }

                return "Chưa thanh toán";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy trạng thái thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "Lỗi";
            }
        }

        /// <summary>
        /// Get payment details for booking
        /// </summary>
        public DataTable GetPaymentDetails(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaThanhToan,
                        MaDatPhong,
                        SoTien,
                        PhuongThucThanhToan,
                        NgayThanhToan,
                        TrangThaiThanhToan
                    FROM ThanhToan
                    WHERE MaDatPhong = @bookingId
                    ORDER BY NgayThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get booking by room ID (for booked rooms)
        /// </summary>
        public DataTable GetBookingByRoomId(int roomId)
        {
            try
            {
                string query = @"
                    SELECT TOP 1
                        dp.MaDatPhong,
                        dp.MaKhachHang,
                        dp.MaPhong,
                        dp.NgayNhan,
                        dp.NgayTra,
                        dp.TrangThai,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.CCCD,
                        kh.DiaChi
                    FROM DatPhong dp
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    WHERE dp.MaPhong = @roomId 
                        AND dp.TrangThai IN (N'Chờ xử lý', N'Đã thanh toán', N'Đang sử dụng')
                    ORDER BY dp.NgayNhan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", roomId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin booking: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Record payment for booking (enhanced version with notes)
        /// </summary>
        public int RecordPayment(int bookingId, decimal totalAmount, string paymentMethod, string notes = "")
        {
            try
            {
                string query = @"
                    INSERT INTO ThanhToan (MaDatPhong, SoTien, PhuongThucThanhToan, NgayThanhToan, TrangThaiThanhToan, GhiChu)
                    VALUES (@bookingId, @amount, @method, GETDATE(), N'Đã thanh toán', @notes)
                    SELECT SCOPE_IDENTITY();";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId),
                    new SqlParameter("@amount", totalAmount),
                    new SqlParameter("@method", paymentMethod),
                    new SqlParameter("@notes", notes ?? "")
                };

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        object result = cmd.ExecuteScalar();
                        int paymentId = result != null ? Convert.ToInt32(result) : 0;

                        if (paymentId > 0)
                        {
                            // Update booking status to "Đã thanh toán"
                            string updateQuery = @"
                                UPDATE DatPhong
                                SET TrangThai = N'Đã thanh toán'
                                WHERE MaDatPhong = @bookingId";

                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@bookingId", bookingId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        return paymentId;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi ghi nhận thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
