using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class DatPhongForm : Form
    {
        private DatPhongBLL bll = new DatPhongBLL();
        private int selectedRoomId = 0;
        private int selectedCustomerId = 0;
        private DataTable roomsDataTable;

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
            // Set default dates
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(1);

            // Load room types
            LoadRoomTypes();

            // Load rooms
            LoadRooms();

            // Load add-on services
            LoadAddOnServices();

            // Setup event handlers
            btnThanhToan.Click += BtnThanhToan_Click;
            btnDong.Click += BtnDong_Click;
            cbLoaiPhong.SelectedIndexChanged += CbLoaiPhong_SelectedIndexChanged;
            dateTimePicker1.ValueChanged += DateTimePicker1_ValueChanged;
            dateTimePicker2.ValueChanged += DateTimePicker2_ValueChanged;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
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

                        btnRoom.Text = roomName + "\n" + status;
                        btnRoom.Width = 80;
                        btnRoom.Height = 60;
                        btnRoom.Margin = new Padding(5);
                        btnRoom.Tag = roomId;
                        btnRoom.Click += BtnRoom_Click;

                        // Use BLL method for color
                        btnRoom.BackColor = bll.GetRoomStatusColor(status);
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
            Button btn = sender as Button;
            if (btn != null)
            {
                selectedRoomId = Convert.ToInt32(btn.Tag);
                ShowRoomDetails();
                CalculatePrice();
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
        /// Load add-on services into data grid
        /// </summary>
        private void LoadAddOnServices()
        {
            try
            {
                DataTable dtServices = bll.GetAddOnServices();
                dgvPhuThu.DataSource = dtServices;
                dgvPhuThu.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dịch vụ phụ thu: " + ex.Message, "Lỗi",
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
                    return;
                }

                DateTime checkIn = dateTimePicker1.Value;
                DateTime checkOut = dateTimePicker2.Value;

                decimal serviceAmount = bll.GetTotalServiceAmount(dgvHoaDonPhong.DataSource as DataTable);
                decimal totalPrice = bll.CalculateTotalPrice(selectedRoomId, checkIn, checkOut, serviceAmount);
                int discountPercent = (int)numericUpDown1.Value;
                decimal finalPrice = bll.ApplyDiscount(totalPrice, discountPercent);

                txtTongTien.Text = bll.FormatCurrency(finalPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính giá: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate customer name is entered
                if (string.IsNullOrWhiteSpace(txtTenKH.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!bll.ValidateCustomerSelected(selectedCustomerId))
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

                // Create booking
                int bookingId = bll.CreateBooking(selectedRoomId, selectedCustomerId, checkIn, checkOut);
                if (bookingId > 0)
                {
                  
                    if (dgvPhuThu.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvPhuThu.SelectedRows)
                        {
                            int serviceId = Convert.ToInt32(row.Cells["MaDichVu"].Value);
                            decimal price = Convert.ToDecimal(row.Cells["Gia"].Value);
                            bll.AddServiceToBooking(bookingId, serviceId, price);
                        }
                    }

                    MessageBox.Show("Đặt phòng thành công! Mã đặt phòng: " + bookingId, "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
