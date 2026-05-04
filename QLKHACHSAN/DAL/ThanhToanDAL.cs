using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for Thanh Toán (Payment)
    /// Handles all database operations for payment processing
    /// </summary>
    public class ThanhToanDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Get booking details by room ID (for already booked rooms)
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
        /// Get booking details by booking ID
        /// </summary>
        public DataTable GetBookingDetails(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT 
                        dp.MaDatPhong,
                        dp.MaKhachHang,
                        dp.MaPhong,
                        dp.NgayNhan,
                        dp.NgayTra,
                        dp.TrangThai,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.CCCD,
                        kh.DiaChi,
                        p.SoPhong,
                        lp.TenLoaiPhong,
                        lp.Gia
                    FROM DatPhong dp
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE dp.MaDatPhong = @bookingId";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy chi tiết booking: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get booking services/add-ons
        /// </summary>
        public DataTable GetBookingServices(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT 
                        dd.MaDatDichVu,
                        dd.MaDichVu,
                        dv.TenDichVu,
                        dd.ThanhTien,
                        dd.NgayThanhToan
                    FROM DatDichVu dd
                    INNER JOIN DichVu dv ON dd.MaDichVu = dv.MaDichVu
                    WHERE dd.MaDatPhong = @bookingId";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Calculate total booking amount (room + services)
        /// </summary>
        public decimal CalculateTotalAmount(int bookingId)
        {
            try
            {
                string query = @"
                    DECLARE @RoomPrice DECIMAL(10,2);
                    DECLARE @ServiceTotal DECIMAL(10,2);
                    DECLARE @Days INT;

                    SELECT 
                        @Days = DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra),
                        @RoomPrice = lp.Gia
                    FROM DatPhong dp
                    INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE dp.MaDatPhong = @bookingId;

                    IF @Days = 0 SET @Days = 1;

                    SELECT ISNULL(SUM(ThanhTien), 0) INTO @ServiceTotal
                    FROM DatDichVu
                    WHERE MaDatPhong = @bookingId;

                    SELECT (@RoomPrice * @Days) + @ServiceTotal as TotalAmount";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["TotalAmount"] ?? 0);
                }

                return 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tính tổng tiền: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Get existing payment for booking
        /// </summary>
        public DataTable GetPaymentInfo(int bookingId)
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
                        TrangThaiThanhToan,
                        GhiChu
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
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Update booking status
        /// </summary>
        public bool UpdateBookingStatus(int bookingId, string status)
        {
            try
            {
                string query = @"
                    UPDATE DatPhong
                    SET TrangThaiDatPhong = @status
                    WHERE MaDatPhong = @bookingId";

                SqlParameter[] parameters = {
                    new SqlParameter("@bookingId", bookingId),
                    new SqlParameter("@status", status)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
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
                string query = @"
                    UPDATE Phong
                    SET TrangThai = @status
                    WHERE MaPhong = @roomId";

                SqlParameter[] parameters = {
                    new SqlParameter("@roomId", roomId),
                    new SqlParameter("@status", status)
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi cập nhật trạng thái phòng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
