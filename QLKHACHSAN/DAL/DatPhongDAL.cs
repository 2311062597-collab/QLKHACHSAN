using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLKHACHSAN.DAL
{
    public class DatPhongDAL
    {
        private DBConnection db = new DBConnection();

        // =========================
        // 1. PHÒNG / LOẠI PHÒNG
        // =========================

        public DataTable GetAllRooms()
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong AS TenPhong,
                        p.Tang,
                        lp.TenLoaiPhong,
                        p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    ORDER BY p.Tang, p.SoPhong";

                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy danh sách phòng", ex);
                return new DataTable();
            }
        }

        public DataTable GetRoomsByType(int roomTypeId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong AS TenPhong,
                        lp.TenLoaiPhong,
                        p.TrangThai
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaLoaiPhong = @roomTypeId
                    ORDER BY p.SoPhong";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@roomTypeId", roomTypeId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy phòng theo loại", ex);
                return new DataTable();
            }
        }

        public DataTable GetAllRoomTypes()
        {
            try
            {
                string query = @"
                    SELECT MaLoaiPhong, TenLoaiPhong
                    FROM LoaiPhong
                    ORDER BY TenLoaiPhong";

                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy loại phòng", ex);
                return new DataTable();
            }
        }

        public DataTable GetRoomDetails(int roomId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong AS TenPhong,
                        p.TrangThai,
                        lp.MaLoaiPhong,
                        lp.TenLoaiPhong,
                        lp.Gia
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@roomId", roomId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy chi tiết phòng", ex);
                return new DataTable();
            }
        }

        public decimal GetRoomPrice(int roomId)
        {
            try
            {
                string query = @"
                    SELECT lp.Gia
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@roomId", roomId)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["Gia"]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy giá phòng", ex);
                return 0;
            }
        }

        public bool IsRoomAvailable(int roomId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) AS BookingCount
                    FROM DatPhong
                    WHERE MaPhong = @roomId
                        AND NgayNhan < @checkOut
                        AND NgayTra > @checkIn
                        AND TrangThai IN 
                        (
                            N'Chờ xử lý',
                            N'Đã xác nhận',
                            N'Đang sử dụng',
                            N'Đã thanh toán'
                        )";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@roomId", roomId),
                    new SqlParameter("@checkIn", checkIn.Date),
                    new SqlParameter("@checkOut", checkOut.Date)
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["BookingCount"]);
                    return count == 0;
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi kiểm tra phòng trống", ex);
                return false;
            }
        }

        // =========================
        // 2. KHÁCH HÀNG
        // =========================

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

                SqlParameter[] parameters =
                {
                    new SqlParameter("@phone", phoneNumber)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tìm khách hàng theo số điện thoại", ex);
                return new DataTable();
            }
        }

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

                SqlParameter[] parameters =
                {
                    new SqlParameter("@cccd", identityNumber)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi tìm khách hàng theo CCCD", ex);
                return new DataTable();
            }
        }
        public int CreateCustomer(string hoTen, string soDienThoai, string cccd)
        {
            try
            {
                string query = @"
            INSERT INTO KhachHang
            (
                HoTen,
                SoDienThoai,
                CCCD
            )
            VALUES
            (
                @hoTen,
                @soDienThoai,
                @cccd
            );

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                SqlParameter[] parameters =
                {
            new SqlParameter("@hoTen", hoTen),
            new SqlParameter("@soDienThoai", soDienThoai),
            new SqlParameter("@cccd", cccd)
        };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0]);
                }

                return 0;
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi thêm khách hàng mới", ex);
                return 0;
            }
        }
        // =========================
        // 3. ĐẶT PHÒNG
        // =========================

        public int CreateBooking(int roomId, int customerId, DateTime checkIn, DateTime checkOut)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = db.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                string insertQuery = @"
                    INSERT INTO DatPhong 
                    (
                        MaKhachHang, 
                        MaPhong, 
                        MaNhanVien, 
                        NgayNhan, 
                        NgayTra, 
                        TrangThai
                    )
                    VALUES 
                    (
                        @customerId, 
                        @roomId, 
                        1, 
                        @checkIn, 
                        @checkOut, 
                        N'Chờ xử lý'
                    );

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int bookingId = 0;

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@checkIn", checkIn.Date);
                    cmd.Parameters.AddWithValue("@checkOut", checkOut.Date);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        bookingId = Convert.ToInt32(result);
                    }
                }

                if (bookingId > 0)
                {
                    string updateRoomQuery = @"
                        UPDATE Phong
                        SET TrangThai = N'Đã đặt'
                        WHERE MaPhong = @roomId";

                    using (SqlCommand cmd = new SqlCommand(updateRoomQuery, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@roomId", roomId);
                        cmd.ExecuteNonQuery();
                    }
                }

                tran.Commit();
                return bookingId;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }

                ShowError("Lỗi khi tạo đặt phòng", ex);
                return 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

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
                        dp.TrangThai AS TrangThaiDatPhong,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.CCCD,
                        p.SoPhong AS TenPhong,
                        p.TrangThai AS TrangThaiPhong,
                        lp.TenLoaiPhong,
                        lp.Gia
                    FROM DatPhong dp
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE dp.MaDatPhong = @bookingId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy chi tiết đặt phòng", ex);
                return new DataTable();
            }
        }

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
                p.SoPhong AS TenPhong,
                p.TrangThai AS TrangThaiPhong
            FROM DatPhong dp
            INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
            INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
            WHERE dp.MaPhong = @roomId
                AND p.TrangThai <> N'Còn trống'
                AND dp.TrangThai IN 
                (
                    N'Chờ xử lý',
                    N'Đã đặt',
                    N'Đã xác nhận',
                    N'Đang sử dụng'
                )
            ORDER BY dp.MaDatPhong DESC";

                SqlParameter[] parameters =
                                {
                    new SqlParameter("@roomId", roomId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
            
                ShowError("Lỗi khi lấy thông tin booking: ", ex);
                return new DataTable();
            }
        }

        public bool CompleteBooking(int bookingId, DateTime checkOutDate)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = db.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                int roomId = 0;

                string getRoomQuery = @"
                    SELECT MaPhong
                    FROM DatPhong
                    WHERE MaDatPhong = @bookingId";

                using (SqlCommand cmd = new SqlCommand(getRoomQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        roomId = Convert.ToInt32(result);
                    }
                }

                if (roomId <= 0)
                {
                    tran.Rollback();
                    return false;
                }

                string updateBookingQuery = @"
                    UPDATE DatPhong
                    SET TrangThai = N'Đã trả phòng',
                        NgayTra = @checkOutDate
                    WHERE MaDatPhong = @bookingId";

                using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate.Date);
                    cmd.ExecuteNonQuery();
                }

                string updateRoomQuery = @"
                    UPDATE Phong
                    SET TrangThai = N'Còn trống'
                    WHERE MaPhong = @roomId";

                using (SqlCommand cmd = new SqlCommand(updateRoomQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }

                ShowError("Lỗi khi hoàn tất checkout", ex);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // =========================
        // 4. HÓA ĐƠN TIỀN PHÒNG
        // =========================

        public DataTable GetRoomInvoiceInfo(int roomId, DateTime checkIn, DateTime checkOut)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.MaPhong,
                        p.SoPhong AS TenPhong,
                        lp.TenLoaiPhong,
                        lp.Gia AS DonGia,
                        @checkIn AS NgayNhan,
                        @checkOut AS NgayTra,
                        CASE
                            WHEN DATEDIFF(DAY, @checkIn, @checkOut) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, @checkIn, @checkOut)
                        END AS SoDem,
                        lp.Gia *
                        CASE
                            WHEN DATEDIFF(DAY, @checkIn, @checkOut) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, @checkIn, @checkOut)
                        END AS ThanhTien
                    FROM Phong p
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE p.MaPhong = @roomId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@roomId", roomId),
                    new SqlParameter("@checkIn", checkIn.Date),
                    new SqlParameter("@checkOut", checkOut.Date)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy hóa đơn tiền phòng", ex);
                return new DataTable();
            }
        }

        public DataTable GetCheckoutInvoice(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT 
                        dp.MaDatPhong,
                        dp.MaPhong,
                        p.SoPhong AS TenPhong,
                        lp.TenLoaiPhong,
                        kh.HoTen,
                        kh.SoDienThoai,
                        kh.CCCD,
                        dp.NgayNhan,
                        dp.NgayTra,
                        lp.Gia AS DonGia,
                        CASE
                            WHEN DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra)
                        END AS SoDem,
                        lp.Gia *
                        CASE
                            WHEN DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra) <= 0 THEN 1
                            ELSE DATEDIFF(DAY, dp.NgayNhan, dp.NgayTra)
                        END AS ThanhTien,
                        dp.TrangThai
                    FROM DatPhong dp
                    INNER JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                    INNER JOIN Phong p ON dp.MaPhong = p.MaPhong
                    INNER JOIN LoaiPhong lp ON p.MaLoaiPhong = lp.MaLoaiPhong
                    WHERE dp.MaDatPhong = @bookingId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy hóa đơn checkout", ex);
                return new DataTable();
            }
        }

        // =========================
        // 5. THANH TOÁN
        // =========================

        public int RecordPayment(int bookingId, decimal totalAmount, string paymentMethod)
        {
            return RecordPayment(bookingId, totalAmount, paymentMethod, "");
        }

        public int RecordPayment(int bookingId, decimal totalAmount, string paymentMethod, string notes)
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = db.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                string insertPaymentQuery = @"
                    INSERT INTO ThanhToan 
                    (
                        MaDatPhong, 
                        SoTien, 
                        PhuongThucThanhToan, 
                        NgayThanhToan, 
                        TrangThaiThanhToan
                    )
                    VALUES 
                    (
                        @bookingId, 
                        @amount, 
                        @method, 
                        GETDATE(), 
                        N'Đã thanh toán'
                    );

                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int paymentId = 0;

                using (SqlCommand cmd = new SqlCommand(insertPaymentQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.Parameters.AddWithValue("@amount", totalAmount);
                    cmd.Parameters.AddWithValue("@method", paymentMethod);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        paymentId = Convert.ToInt32(result);
                    }
                }

                if (paymentId > 0)
                {
                    string updateBookingQuery = @"
                        UPDATE DatPhong
                        SET TrangThai = N'Đã thanh toán'
                        WHERE MaDatPhong = @bookingId";

                    using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@bookingId", bookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                tran.Commit();
                return paymentId;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }

                ShowError("Lỗi khi ghi nhận thanh toán", ex);
                return 0;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public bool CheckoutAndPayment(int bookingId, decimal totalAmount, string paymentMethod, DateTime checkOutDate, string notes = "")
        {
            SqlConnection conn = null;
            SqlTransaction tran = null;

            try
            {
                conn = db.GetConnection();
                conn.Open();
                tran = conn.BeginTransaction();

                int roomId = 0;

                string getRoomQuery = @"
                    SELECT MaPhong
                    FROM DatPhong
                    WHERE MaDatPhong = @bookingId";

                using (SqlCommand cmd = new SqlCommand(getRoomQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        roomId = Convert.ToInt32(result);
                    }
                }

                if (roomId <= 0)
                {
                    tran.Rollback();
                    return false;
                }

                string insertPaymentQuery = @"
                    INSERT INTO ThanhToan 
                    (
                        MaDatPhong, 
                        SoTien, 
                        PhuongThucThanhToan, 
                        NgayThanhToan, 
                        TrangThaiThanhToan
                    )
                    VALUES 
                    (
                        @bookingId, 
                        @amount, 
                        @method, 
                        GETDATE(), 
                        N'Đã thanh toán'
                    )";

                using (SqlCommand cmd = new SqlCommand(insertPaymentQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.Parameters.AddWithValue("@amount", totalAmount);
                    cmd.Parameters.AddWithValue("@method", paymentMethod);
                    cmd.ExecuteNonQuery();
                }

                string updateBookingQuery = @"
                    UPDATE DatPhong
                    SET TrangThai = N'Đã trả phòng',
                        NgayTra = @checkOutDate
                    WHERE MaDatPhong = @bookingId";

                using (SqlCommand cmd = new SqlCommand(updateBookingQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@bookingId", bookingId);
                    cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate.Date);
                    cmd.ExecuteNonQuery();
                }

                string updateRoomQuery = @"
                    UPDATE Phong
                    SET TrangThai = N'Trống'
                    WHERE MaPhong = @roomId";

                using (SqlCommand cmd = new SqlCommand(updateRoomQuery, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }

                ShowError("Lỗi khi thanh toán và checkout", ex);
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public string GetPaymentStatus(int bookingId)
        {
            try
            {
                string query = @"
                    SELECT TOP 1
                        ISNULL(TrangThaiThanhToan, N'Chưa thanh toán') AS PaymentStatus
                    FROM ThanhToan
                    WHERE MaDatPhong = @bookingId
                    ORDER BY MaThanhToan DESC";

                SqlParameter[] parameters =
                {
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
                ShowError("Lỗi khi lấy trạng thái thanh toán", ex);
                return "Lỗi";
            }
        }

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

                SqlParameter[] parameters =
                {
                    new SqlParameter("@bookingId", bookingId)
                };

                return db.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi lấy chi tiết thanh toán", ex);
                return new DataTable();
            }
        }

        // =========================
        // 6. GIỮ LẠI ĐỂ BLL CŨ KHÔNG BỊ LỖI BUILD
        // Sau khi sửa BLL/Form xong có thể xóa các hàm này.
        // =========================

        public DataTable GetAddOnServices()
        {
            return new DataTable();
        }

        public bool AddServiceToBooking(int bookingId, int serviceId, decimal price)
        {
            return true;
        }

        public decimal GetTotalServiceAmount(DataTable dtServices)
        {
            return 0;
        }

        // =========================
        // 7. HELPER
        // =========================

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                message + ": " + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        internal DataTable GetRoomInvoiceInfo(object roomId, DateTime checkIn, DateTime checkOut)
        {
            throw new NotImplementedException();
        }
    }
}