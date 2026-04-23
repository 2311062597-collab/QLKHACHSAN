using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class MuaDichVuForm : Form
    {
        private MuaDichVuBLL bll = new MuaDichVuBLL();
        private KhachHangBLL khachHangBLL = new KhachHangBLL();
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private DichVuBLL dichVuBLL = new DichVuBLL();
        private string selectedId = string.Empty;
        private bool isEditing = false;

        public MuaDichVuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load - Initialize data and UI components
        /// </summary>
        private void MuaDichVuForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            LoadComboBoxData();
            LoadDanhSachDichVu();
            LamMoi();
            WireUpEventHandlers();
        }

        /// <summary>
        /// Load service purchase list from database
        /// </summary>
        private void LoadDanhSachDichVu()
        {
            try
            {
                DataTable dt = bll.GetAll();
                dgvDatDichVu.DataSource = dt;

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Auto-resize columns to fit content
                    dgvDatDichVu.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load data for all combo boxes
        /// </summary>
        private void LoadComboBoxData()
        {
            try
            {
                // Load Customers
                DataTable dtCustomers = khachHangBLL.GetAll();
                cbMaKhachHang.DataSource = dtCustomers;
                cbMaKhachHang.DisplayMember = "TenKhachHang";
                cbMaKhachHang.ValueMember = "MaKhachHang";
                cbMaKhachHang.SelectedIndex = -1;

                // Load Employees
                DataTable dtEmployees = nhanVienBLL.GetDanhSachNhanVien();
                cbMaNhanVien.DataSource = dtEmployees;
                cbMaNhanVien.DisplayMember = "HoTen";
                cbMaNhanVien.ValueMember = "MaNhanVien";
                cbMaNhanVien.SelectedIndex = -1;

                // Load Services
                DataTable dtServices = dichVuBLL.GetDanhSachDichVu();
                cbMaDichVu.DataSource = dtServices;
                cbMaDichVu.DisplayMember = "TenDichVu";
                cbMaDichVu.ValueMember = "MaDichVu";
                cbMaDichVu.SelectedIndex = -1;

                // Load Payment Methods
                LoadPaymentMethods();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu combo box: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load payment methods
        /// </summary>
        private void LoadPaymentMethods()
        {
            cbMaPhuongThuc.Items.Clear();
            cbMaPhuongThuc.Items.Add("Tiền mặt");
            cbMaPhuongThuc.Items.Add("Chuyển khoản");
            cbMaPhuongThuc.Items.Add("Thẻ tín dụng");
            cbMaPhuongThuc.Items.Add("Ví điện tử");
            cbMaPhuongThuc.SelectedIndex = -1;
        }

        /// <summary>
        /// Reset form controls
        /// </summary>
        private void LamMoi()
        {
            selectedId = string.Empty;
            isEditing = false;

            txtMaDatDichVu.Clear();
            cbMaKhachHang.SelectedIndex = -1;
            cbMaNhanVien.SelectedIndex = -1;
            cbMaDichVu.SelectedIndex = -1;
            nudSoLuong.Value = 1;
            txtThanhTien.Text = "0";
            cbMaPhuongThuc.SelectedIndex = -1;
            dtpNgayThanhToan.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtTimMaDatDV.Clear();
            txtTimMaKH.Clear();
        }

        /// <summary>
        /// Wire up event handlers for buttons
        /// </summary>
        private void WireUpEventHandlers()
        {
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnDong.Click += BtnDong_Click;
            btnTim.Click += BtnTim_Click;
            btnTaiLai.Click += BtnTaiLai_Click;
            dgvDatDichVu.CellClick += DgvDatDichVu_CellClick;
            cbMaDichVu.SelectedIndexChanged += CbMaDichVu_SelectedIndexChanged;
            nudSoLuong.ValueChanged += NudSoLuong_ValueChanged;
        }

        /// <summary>
        /// Handle service selection change - calculate total amount
        /// </summary>
        private void CbMaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        /// <summary>
        /// Handle quantity change - recalculate total amount
        /// </summary>
        private void NudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            CalculateThanhTien();
        }

        /// <summary>
        /// Calculate total amount (Thành tiền) based on service and quantity
        /// </summary>
        private void CalculateThanhTien()
        {
            try
            {
                if (cbMaDichVu.SelectedIndex == -1)
                {
                    txtThanhTien.Text = "0";
                    return;
                }

                // Get service price from selected service
                DataTable dt = dichVuBLL.GetDanhSachDichVu();
                if (dt != null && dt.Rows.Count > 0)
                {
                    int maDichVu = Convert.ToInt32(cbMaDichVu.SelectedValue);
                    DataRow[] rows = dt.Select("MaDichVu = " + maDichVu);
                    if (rows.Length > 0)
                    {
                        decimal donGia = Convert.ToDecimal(rows[0]["DonGia"]);
                        int soLuong = (int)nudSoLuong.Value;
                        decimal thanhTien = donGia * soLuong;
                        txtThanhTien.Text = thanhTien.ToString("N2");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính toán thành tiền: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle payment date text change
        /// </summary>
        private void dtpNgayThanhToan_TextChanged(object sender, EventArgs e)
        {
            // Validate or format date here
        }

        /// <summary>
        /// Handle action button click (could be Add, Update, Delete)
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            // Implement action based on button purpose
        }

        /// <summary>
        /// DataGridView cell click - load selected row data to form
        /// </summary>
        private void DgvDatDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvDatDichVu.Rows.Count)
                {
                    DataGridViewRow row = dgvDatDichVu.Rows[e.RowIndex];

                    selectedId = row.Cells["MaDatDichVu"].Value?.ToString() ?? "";
                    isEditing = true;

                    txtMaDatDichVu.Text = selectedId;
                    SetComboBoxValue(cbMaKhachHang, row.Cells["MaKhachHang"].Value);
                    SetComboBoxValue(cbMaNhanVien, row.Cells["MaNhanVien"].Value);
                    SetComboBoxValue(cbMaDichVu, row.Cells["MaDichVu"].Value);

                    nudSoLuong.Value = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 1);
                    txtThanhTien.Text = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0).ToString("N2");

                    // Set payment method based on payment method ID
                    int maPhuongThuc = row.Cells["MaPhuongThuc"].Value != null ? Convert.ToInt32(row.Cells["MaPhuongThuc"].Value) : 1;
                    SetPaymentMethod(maPhuongThuc);

                    dtpNgayThanhToan.Text = Convert.ToDateTime(row.Cells["NgayThanhToan"].Value).ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Helper method to set combo box value
        /// </summary>
        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            if (value != null)
            {
                comboBox.SelectedValue = value;
            }
        }

        /// <summary>
        /// Helper method to set payment method based on ID
        /// </summary>
        private void SetPaymentMethod(int maPhuongThuc)
        {
            switch (maPhuongThuc)
            {
                case 1:
                    cbMaPhuongThuc.SelectedItem = "Tiền mặt";
                    break;
                case 2:
                    cbMaPhuongThuc.SelectedItem = "Chuyển khoản";
                    break;
                case 3:
                    cbMaPhuongThuc.SelectedItem = "Thẻ tín dụng";
                    break;
                case 4:
                    cbMaPhuongThuc.SelectedItem = "Ví điện tử";
                    break;
                default:
                    cbMaPhuongThuc.SelectedItem = "Tiền mặt";
                    break;
            }
        }

        /// <summary>
        /// Button Add - prepare form for new entry
        /// </summary>
        private void BtnThem_Click(object sender, EventArgs e)
        {
            LamMoi();
            isEditing = false;
            GenerateMaDatDichVu();
        }

        /// <summary>
        /// Generate new service purchase ID
        /// </summary>
        private void GenerateMaDatDichVu()
        {
            try
            {
                DataTable dt = bll.GetAll();
                int maxId = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string maDatDichVu = row["MaDatDichVu"].ToString();
                    if (maDatDichVu.StartsWith("DDV"))
                    {
                        string numPart = maDatDichVu.Substring(3);
                        if (int.TryParse(numPart, out int id))
                        {
                            if (id > maxId)
                                maxId = id;
                        }
                    }
                }

                txtMaDatDichVu.Text = "DDV" + (maxId + 1).ToString("D4");
            }
            catch
            {
                txtMaDatDichVu.Text = "DDV" + DateTime.Now.ToString("MMddHHmmss").Substring(0, 4);
            }
        }

        /// <summary>
        /// Button Update - prepare form for editing
        /// </summary>
        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedId))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
        }

        /// <summary>
        /// Button Delete - delete selected service purchase
        /// </summary>
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedId))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bll.Xoa(selectedId))
            {
                MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachDichVu();
                LamMoi();
            }
        }

        /// <summary>
        /// Button Save - save new or updated service purchase
        /// </summary>
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (cbMaKhachHang.SelectedIndex == -1 ||
                    cbMaNhanVien.SelectedIndex == -1 ||
                    cbMaDichVu.SelectedIndex == -1 ||
                    cbMaPhuongThuc.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maDatDichVu = txtMaDatDichVu.Text.Trim();
                string maKhachHang = cbMaKhachHang.SelectedValue?.ToString() ?? "";
                string maNhanVien = cbMaNhanVien.SelectedValue?.ToString() ?? "";
                string maDichVu = cbMaDichVu.SelectedValue?.ToString() ?? "";
                int soLuong = (int)nudSoLuong.Value;
                decimal thanhTien = Convert.ToDecimal(txtThanhTien.Text);

                // Convert payment method name to ID
                int maPhuongThuc = GetPaymentMethodId(cbMaPhuongThuc.SelectedItem.ToString());
                DateTime ngayThanhToan = DateTime.ParseExact(dtpNgayThanhToan.Text, "dd/MM/yyyy", null);

                bool result = false;

                if (isEditing)
                {
                    result = bll.Sua(maDatDichVu, maKhachHang, maNhanVien, maDichVu,
                        soLuong, thanhTien, maPhuongThuc.ToString(), ngayThanhToan);

                    if (result)
                        MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    result = bll.Them(maKhachHang, maNhanVien, maDichVu,
                        soLuong, thanhTien, maPhuongThuc.ToString(), ngayThanhToan);

                    if (result)
                        MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (result)
                {
                    LoadDanhSachDichVu();
                    LamMoi();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Helper method to convert payment method name to ID
        /// </summary>
        private int GetPaymentMethodId(string paymentMethodName)
        {
            switch (paymentMethodName)
            {
                case "Tiền mặt":
                    return 1;
                case "Chuyển khoản":
                    return 2;
                case "Thẻ tín dụng":
                    return 3;
                case "Ví điện tử":
                    return 4;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// Button Refresh - refresh form
        /// </summary>
        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        /// <summary>
        /// Button Close - close form
        /// </summary>
        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Button Search - search by customer ID
        /// </summary>
        private void BtnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtTimMaKH.Text))
                {
                    DataTable dt = bll.SearchByCustomer(txtTimMaKH.Text.Trim());
                    dgvDatDichVu.DataSource = dt;
                }
                else if (!string.IsNullOrWhiteSpace(txtTimMaDatDV.Text))
                {
                    DataTable dt = bll.GetById(txtTimMaDatDV.Text.Trim());
                    dgvDatDichVu.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã đặt dịch vụ hoặc mã khách hàng!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Reload - reload all data
        /// </summary>
        private void BtnTaiLai_Click(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDanhSachDichVu();
            LamMoi();
        }
    }
}
