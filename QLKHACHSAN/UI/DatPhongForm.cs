using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class DatPhongForm : Form
    {
        private DatPhongBLL bll = new DatPhongBLL();
        private ThongKeBLL thongKeBLL = new ThongKeBLL();
        private int selectedRoomId = 0;
        private int selectedCustomerId = 0;
        private int filterTang = 0; // 0 = tất cả tầng
        private DataTable roomsDataTable;
        private readonly DataTable dtServices;
        private PrintDocument printLaiHoaDonDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewHoaDon = new PrintPreviewDialog();
        private DataGridViewRow selectedInvoiceRow = null;

        public DatPhongForm()
        {
            InitializeComponent();
            this.Load += DatPhongForm_Load;
        }

        private void DatPhongForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeForm();

                // Add event handlers for customer info fields
                txtCCCD.TextChanged += TxtCCCD_TextChanged;
                txtSDT.TextChanged += TxtSDT_TextChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initialize form controls and data
        /// </summary>
        private void InitializeForm()
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);

            LoadTang();

            LoadRoomTypes();
            LoadRooms();

            btnDong.Click += BtnDong_Click;
            btnInLaiHoaDon.Click += BtnInLaiHoaDon_Click;
            printLaiHoaDonDocument.PrintPage += PrintLaiHoaDonDocument_PrintPage;

            cbLoaiPhong.SelectedIndexChanged += CbLoaiPhong_SelectedIndexChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;

        }

        private void LoadTang()
        {
            cbTang.Items.Clear();
            cbTang.Items.Add("Tất cả tầng");

            for (int i = 1; i <= 9; i++)
            {
                cbTang.Items.Add("Tầng " + i);
            }

            cbTang.SelectedIndex = 0;
        }

        private void CbTang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTang.SelectedIndex <= 0)
            {
                filterTang = 0;
            }
            else
            {
                filterTang = cbTang.SelectedIndex;
            }

            DisplayRoomGrid();
        }

        /// <summary>
        /// Load room types into combo box
        /// </summary>
        private void LoadRoomTypes()
        {
            try
            {
                DataTable dtRoomTypes = bll.GetAllRoomTypes();
                cbLoaiPhong.DataSource = dtRoomTypes;
                cbLoaiPhong.DisplayMember = "TenLoaiPhong";
                cbLoaiPhong.ValueMember = "MaLoaiPhong";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load all rooms and display as buttons
        /// </summary>
        private void LoadRooms()
        {
            try
            {
                roomsDataTable = bll.GetAllRooms();
                if (roomsDataTable == null || roomsDataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phòng nào trong cơ sở dữ liệu.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DisplayRoomGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Display rooms as clickable buttons
        /// </summary>
        private Color GetRoomTypeColor(string tenLoaiPhong)
        {
            tenLoaiPhong = tenLoaiPhong.Trim().ToLower();

            if (tenLoaiPhong.Contains("đơn") || tenLoaiPhong.Contains("don"))
                return Color.Orange;

            if (tenLoaiPhong.Contains("đôi") || tenLoaiPhong.Contains("doi"))
                return Color.DodgerBlue;

            if (tenLoaiPhong.Contains("vip"))
                return Color.MediumPurple;

            return Color.Gray;
        }
        private void DisplayRoomGrid()
        {
            try
            {
                flpPhong.Controls.Clear();

                if (roomsDataTable == null || roomsDataTable.Rows.Count == 0)
                    return;

                foreach (DataRow row in roomsDataTable.Rows)
                {
                    try
                    {
                        Button btnRoom = new Button();
                        int roomId = Convert.ToInt32(row["MaPhong"]);
                        string roomName = row["TenPhong"].ToString();
                        string status = row["TrangThai"].ToString();
                        string tenLoaiPhong = row["TenLoaiPhong"].ToString();
                        string tang = row["Tang"].ToString();
                        if (filterTang > 0 && tang != filterTang.ToString())
                        {
                            continue;
                        }

                        btnRoom.Text = "P." + roomName + "\nTầng " + tang + "\n" + status;
                        btnRoom.Width = 90;
                        btnRoom.Height = 70;
                        btnRoom.Margin = new Padding(5);
                        btnRoom.Tag = roomId;
                        btnRoom.Click += BtnRoom_Click;

                        if (status.Trim().ToLower().Contains("đã đặt") ||
                        status.Trim().ToLower().Contains("đang sử dụng"))
                        {
                            btnRoom.BackColor = Color.Gray;
                        }
                        else
                        {
                            btnRoom.BackColor = GetRoomTypeColor(tenLoaiPhong);
                        }

                        btnRoom.ForeColor = Color.White;
                        btnRoom.Font = new Font("Arial", 8, FontStyle.Bold);
                        flpPhong.Controls.Add(btnRoom);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tạo nút phòng: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle room button click
        /// </summary>
        private void BtnRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn == null)
                    return;

                selectedRoomId = Convert.ToInt32(btn.Tag);

                // Check if room is already booked
                DataTable dtBooking = bll.GetBookingByRoomId(selectedRoomId);
                if (dtBooking != null && dtBooking.Rows.Count > 0)
                {
                    // Room has active booking - load customer info and ask about payment
                    LoadBookedRoomInfo(dtBooking);
                }
                else
                {
                    // Room is available - show normal room details
                    ShowRoomDetails();
                    CalculatePrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load booked room information and auto-fill customer info
        /// </summary>
        private void LoadBookedRoomInfo(DataTable dtBooking)
        {
            try
            {
                if (dtBooking.Rows.Count == 0)
                    return;

                DataRow row = dtBooking.Rows[0];
                int bookingId = Convert.ToInt32(row["MaDatPhong"]);

                // Auto-fill customer information
                selectedCustomerId = Convert.ToInt32(row["MaKhachHang"]);
                txtTenKH.Text = row["HoTen"].ToString();
                txtSDT.Text = row["SoDienThoai"].ToString();
                txtCCCD.Text = row["CCCD"].ToString();

                // Show room details
                DataTable dtRoomDetails = bll.GetRoomDetails(selectedRoomId);
                if (dtRoomDetails != null && dtRoomDetails.Rows.Count > 0)
                {
                    txtTenPhong.Text = dtRoomDetails.Rows[0]["TenPhong"].ToString();
                    cbLoaiPhong.SelectedValue = Convert.ToInt32(dtRoomDetails.Rows[0]["MaLoaiPhong"]);
                }

                // Load booking dates
                DateTime checkIn = Convert.ToDateTime(row["NgayNhan"]);
                DateTime checkOut = Convert.ToDateTime(row["NgayTra"]);
                dateTimePicker1.Value = checkIn;
                dateTimePicker2.Value = checkOut;

                // Ask user if they want to process payment
                DialogResult result = MessageBox.Show(
                    $"Phòng này đã có đặt phòng:\n\n" +
                    $"Khách hàng: {row["HoTen"]}\n" +
                    $"Ngày nhận: {checkIn:dd/MM/yyyy}\n" +
                    $"Ngày trả: {checkOut:dd/MM/yyyy}\n\n" +
                    $"Bạn có muốn thanh toán cho booking này không?",
                    "Phòng Đã Đặt",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Open checkout form
                    CheckoutForm checkoutForm = new CheckoutForm(bookingId);
                    if (checkoutForm.ShowDialog() == DialogResult.OK)
                    {
                        // Reload rooms to update status
                        LoadRooms();
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin phòng đã đặt: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show selected room details
        /// </summary>
        private void ShowRoomDetails()
        {
            try
            {
                if (selectedRoomId == 0) return;

                DataTable dtRoom = bll.GetRoomDetails(selectedRoomId);
                if (dtRoom != null && dtRoom.Rows.Count > 0)
                {
                    DataRow row = dtRoom.Rows[0];
                    txtTenPhong.Text = row["TenPhong"].ToString();
                    cbLoaiPhong.SelectedValue = Convert.ToInt32(row["MaLoaiPhong"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Handle room type selection change
        /// </summary>
        private void CbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        /// <summary>
        /// Handle check-in date change
        /// </summary>
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (bll.ValidateCheckinDate(dateTimePicker1.Value))
            {
                if (dateTimePicker2.Value <= dateTimePicker1.Value)
                {
                    dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
                }
                CalculatePrice();
            }
            else
            {
                dateTimePicker1.Value = DateTime.Now;
            }
        }

      
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (bll.ValidateCheckoutDate(dateTimePicker2.Value, dateTimePicker1.Value))
            {
                CalculatePrice();
            }
            else
            {
                dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
            }
        }

       
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }


        private void CalculatePrice()
        {
            try
            {
                if (selectedRoomId == 0)
                {
                    txtTongTien.Text = "0 đ";
                    LoadPaymentHistory();
                    return;
                }

                DateTime checkIn = dateTimePicker1.Value;
                DateTime checkOut = dateTimePicker2.Value;

                DataTable dtInvoice = bll.CreateRoomInvoice(selectedRoomId, checkIn, checkOut);

                decimal totalPrice = 0;

                if (dtInvoice != null && dtInvoice.Rows.Count > 0)
                {
                    foreach (DataRow row in dtInvoice.Rows)
                    {
                        totalPrice += Convert.ToDecimal(row["ThanhTien"]);
                    }
                }

                // Apply discount
                int discountPercent = (int)numericUpDown1.Value;
                decimal finalPrice = bll.ApplyDiscount(totalPrice, discountPercent);

                txtTongTien.Text = bll.FormatCurrency(finalPrice);

                // Load payment history instead of invoice
                LoadPaymentHistory();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("===== CALCULATE PRICE ERROR =====");
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                MessageBox.Show("Lỗi khi tính giá: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load payment history from current month to today
        /// </summary>
        private void LoadPaymentHistory()
        {
            try
            {
                // Get payment history for current month
                DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime toDate = DateTime.Now.Date;

                DataTable dtPaymentHistory = thongKeBLL.GetAllDetailedTransactions(fromDate, toDate);

                if (dtPaymentHistory != null && dtPaymentHistory.Rows.Count > 0)
                {
                    dgvHoaDonPhong.DataSource = dtPaymentHistory;
                    dgvHoaDonPhong.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    dgvHoaDonPhong.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("===== LOAD PAYMENT HISTORY ERROR =====");
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                MessageBox.Show("Lỗi khi tải lịch sử thanh toán: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Extract amount from currency formatted text
        /// </summary>
        private decimal ExtractAmountFromTextBox(string text)
        {
            try
            {
                // Remove currency symbols and spaces
                string cleanText = text.Replace("₫", "").Replace("đ", "").Replace(",", "").Trim();
                if (decimal.TryParse(cleanText, out decimal amount))
                {
                    return amount;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error extracting amount: {ex.Message}");
            }
            return 0;
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("=== Booking Process Started ===");

                // Validate customer name is entered
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!EnsureCustomerExists())
                    return;

                if (!bll.ValidateRoomSelected(selectedRoomId))
                    return;

                DateTime checkIn = dateTimePicker1.Value;
                DateTime checkOut = dateTimePicker2.Value;

                // Check room availability
                if (!bll.IsRoomAvailable(selectedRoomId, checkIn, checkOut))
                {
                    MessageBox.Show("Phòng không khả dụng trong khoảng thời gian này!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                System.Diagnostics.Debug.WriteLine($"Creating booking for Customer={selectedCustomerId}, Room={selectedRoomId}, CheckIn={checkIn:yyyy-MM-dd}, CheckOut={checkOut:yyyy-MM-dd}");

                // Create booking
                int bookingId = bll.CreateBooking(selectedRoomId, selectedCustomerId, checkIn, checkOut);
                if (bookingId > 0)
                {
                    System.Diagnostics.Debug.WriteLine($"Booking created successfully. BookingId={bookingId}");

                    System.Diagnostics.Debug.WriteLine("Booking created successfully. Opening checkout form...");

                    // Open checkout form
                    CheckoutForm checkoutForm = new CheckoutForm(bookingId);
                    if (checkoutForm.ShowDialog() == DialogResult.OK)
                    {
                        System.Diagnostics.Debug.WriteLine("=== Booking Process Completed Successfully ===");
                        ClearForm();
                        LoadRooms();
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("Checkout cancelled by user");
                        MessageBox.Show("Đặt phòng thành công nhưng chưa thanh toán!\nMã đặt phòng: " + bookingId, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadRooms();
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Failed to create booking");
                    MessageBox.Show("Lỗi khi tạo đặt phòng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in BtnThanhToan_Click: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearForm()
        {
            selectedRoomId = 0;
            selectedCustomerId = 0;
            txtTenKH.Clear();
            txtSDT.Clear();
            txtCCCD.Clear();
            txtTenPhong.Clear();
            txtTongTien.Text = "0 đ";
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);
            dgvHoaDonPhong.DataSource = null;
            
        }

      
        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void TxtCCCD_TextChanged(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Length == 12)
            {
                SearchCustomerByIdentity(txtCCCD.Text);
            }
        }

      
        private void TxtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Length == 10 && txtSDT.Text.All(char.IsDigit))
            {
                SearchCustomerByPhone(txtSDT.Text);
            }
        }

       
        private void SearchCustomerByPhone(string phoneNumber)
        {
            try
            {
                DataTable dt = bll.GetCustomerByPhone(phoneNumber);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    selectedCustomerId = Convert.ToInt32(row["MaKhachHang"]);
                    txtTenKH.Text = row["HoTen"].ToString();
                    txtCCCD.Text = row["CCCD"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void SearchCustomerByIdentity(string identityNumber)
        {
            try
            {
                DataTable dt = bll.GetCustomerByIdentity(identityNumber);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    selectedCustomerId = Convert.ToInt32(row["MaKhachHang"]);
                    txtTenKH.Text = row["HoTen"].ToString();
                    txtSDT.Text = row["SoDienThoai"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm khách hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool EnsureCustomerExists()
        {
            try
            {
                // Nếu đã tìm thấy khách hàng rồi thì dùng luôn
                if (selectedCustomerId > 0)
                    return true;

                string hoTen = txtTenKH.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string cccd = txtCCCD.Text.Trim();

                if (string.IsNullOrWhiteSpace(hoTen))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKH.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(sdt) || sdt.Length != 10 || !sdt.All(char.IsDigit))
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSDT.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(cccd) || cccd.Length != 12 || !cccd.All(char.IsDigit))
                {
                    MessageBox.Show("CCCD phải đủ 12 số!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCCCD.Focus();
                    return false;
                }

                // Kiểm tra lại theo số điện thoại
                DataTable dtByPhone = bll.GetCustomerByPhone(sdt);
                if (dtByPhone != null && dtByPhone.Rows.Count > 0)
                {
                    DataRow row = dtByPhone.Rows[0];
                    selectedCustomerId = Convert.ToInt32(row["MaKhachHang"]);
                    txtTenKH.Text = row["HoTen"].ToString();
                    txtCCCD.Text = row["CCCD"].ToString();
                    return true;
                }

                // Kiểm tra lại theo CCCD
                DataTable dtByCCCD = bll.GetCustomerByIdentity(cccd);
                if (dtByCCCD != null && dtByCCCD.Rows.Count > 0)
                {
                    DataRow row = dtByCCCD.Rows[0];
                    selectedCustomerId = Convert.ToInt32(row["MaKhachHang"]);
                    txtTenKH.Text = row["HoTen"].ToString();
                    txtSDT.Text = row["SoDienThoai"].ToString();
                    return true;
                }

                // Nếu khách chưa tồn tại thì tự thêm mới
                int newCustomerId = bll.CreateCustomer(hoTen, sdt, cccd);

                if (newCustomerId <= 0)
                {
                    MessageBox.Show("Không thể thêm khách hàng mới!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                selectedCustomerId = newCustomerId;

                MessageBox.Show("Đã thêm khách hàng mới vào hệ thống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra/thêm khách hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void grbDanhSachPhong_Enter(object sender, EventArgs e)
        {

        }

        private void dgvHoaDonPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void BtnInLaiHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDonPhong.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Vui lòng chọn một hóa đơn trong lịch sử thanh toán để in lại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                selectedInvoiceRow = dgvHoaDonPhong.CurrentRow;

                printPreviewHoaDon.Document = printLaiHoaDonDocument;
                printPreviewHoaDon.Width = 900;
                printPreviewHoaDon.Height = 700;
                printPreviewHoaDon.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi in lại hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            try
            {
                if (row == null)
                    return "";

                if (!dgvHoaDonPhong.Columns.Contains(columnName))
                    return "";

                object value = row.Cells[columnName].Value;

                if (value == null || value == DBNull.Value)
                    return "";

                return value.ToString();
            }
            catch
            {
                return "";
            }
        }

        private void PrintLaiHoaDonDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (selectedInvoiceRow == null)
                return;

            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 13, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11, FontStyle.Regular);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            float y = 40;
            float left = 60;
            float lineHeight = 28;

            string loaiGiaoDich = GetCellValue(selectedInvoiceRow, "LoaiGiaoDich");
            string maHoaDon = GetCellValue(selectedInvoiceRow, "MaHoaDon");
            string tenKhachHang = GetCellValue(selectedInvoiceRow, "TenKhachHang");
            string tenChiTieu = GetCellValue(selectedInvoiceRow, "TenChiTieu");
            string doanhThu = GetCellValue(selectedInvoiceRow, "DoanhThu");
            string ngayThanhToan = GetCellValue(selectedInvoiceRow, "NgayThanhToan");
            string phuongThuc = GetCellValue(selectedInvoiceRow, "PhuongThuc");

            e.Graphics.DrawString("TAKIVIVU HOTEL", titleFont, Brushes.Black, left + 210, y);
            y += 40;

            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", headerFont, Brushes.Black, left + 190, y);
            y += 40;

            e.Graphics.DrawString("Mã hóa đơn: " + maHoaDon, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Loại giao dịch: " + loaiGiaoDich, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Ngày thanh toán: " + ngayThanhToan, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Ngày in lại: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont, Brushes.Black, left, y);
            y += lineHeight + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 680, y);
            y += 20;

            e.Graphics.DrawString("Tên khách hàng: " + tenKhachHang, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Nội dung: " + tenChiTieu, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Phương thức: " + phuongThuc, normalFont, Brushes.Black, left, y);
            y += lineHeight + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 680, y);
            y += 20;

            e.Graphics.DrawString("SỐ TIỀN:", boldFont, Brushes.Black, left, y);
            e.Graphics.DrawString(doanhThu + " đ", boldFont, Brushes.Black, left + 220, y);
            y += lineHeight + 40;

            e.Graphics.DrawString("Nhân viên xác nhận", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Khách hàng", normalFont, Brushes.Black, left + 460, y);
            y += 90;

            e.Graphics.DrawString("Cảm ơn quý khách đã sử dụng dịch vụ!", boldFont, Brushes.Black, left + 150, y);
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!EnsureCustomerExists())
                    return;

                if (!bll.ValidateRoomSelected(selectedRoomId))
                    return;

                DateTime checkIn = dateTimePicker1.Value;
                DateTime checkOut = dateTimePicker2.Value;

                if (!bll.IsRoomAvailable(selectedRoomId, checkIn, checkOut))
                {
                    MessageBox.Show("Phòng không khả dụng trong khoảng thời gian này!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int bookingId = bll.CreateBooking(selectedRoomId, selectedCustomerId, checkIn, checkOut);

                if (bookingId > 0)
                {
                    MessageBox.Show("Đặt phòng thành công!\nMã đặt phòng: " + bookingId,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearForm();
                    LoadRooms();
                }
                else
                {
                    MessageBox.Show("Lỗi khi tạo đặt phòng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đặt phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnInLaiHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}
