using System;
using System.Data;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class NhanVienForm : Form
    {
        private NhanVienBLL bll = new NhanVienBLL();

        private int maNhanVien = 0;
        private int maTaiKhoan = 0;

        public NhanVienForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.NhanVienForm_Load);
            this.dgvBangNV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBangNV_CellDoubleClick);

        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            LoadChucVu();
            LoadTrangThai();
            LoadDanhSachNhanVien();
            LamMoi();
            
        }

        private void LoadDanhSachNhanVien()
        {
            dgvBangNV.DataSource = bll.GetDanhSachNhanVien();

            if (dgvBangNV.Columns.Contains("MaNhanVien"))
                dgvBangNV.Columns["MaNhanVien"].Visible = false;

            if (dgvBangNV.Columns.Contains("MaTaiKhoan"))
                dgvBangNV.Columns["MaTaiKhoan"].Visible = false;

            if (dgvBangNV.Columns.Contains("MaChucVu"))
                dgvBangNV.Columns["MaChucVu"].Visible = false;
        }

        private void LoadChucVu()
        {
            DataTable dt = bll.GetChucVu();
            cbCVNV.DataSource = dt;
            cbCVNV.DisplayMember = "TenChucVu";
            cbCVNV.ValueMember = "MaChucVu";
            cbCVNV.SelectedIndex = -1;
        }

        private void LoadTrangThai()
        {
            cbTrangThaiNV.Items.Clear();
            cbTrangThaiNV.Items.Add("Hoạt động");
            cbTrangThaiNV.Items.Add("Đã khóa");
            cbTrangThaiNV.SelectedIndex = 0;
            cbTrangThaiNV.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LamMoi()
        {
            maNhanVien = 0;
            maTaiKhoan = 0;

            txtTKNV.Clear();
            txtMKNV.Clear();
            txtTenNV.Clear();
            txtCCCDNV.Clear();
            txtSDTNV.Clear();
            txtDCNV.Clear();
            txtTimNV.Clear();

            radNamNV.Checked = false;
            radNuNV.Checked = false;

            cbCVNV.SelectedIndex = -1;
            cbTrangThaiNV.SelectedIndex = 0;
            lbl.Text = "";
        }

        private string LayGioiTinh()
        {
            if (radNamNV.Checked) return "Nam";
            if (radNuNV.Checked) return "Nữ";
            return "";
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtTKNV.Text.Trim() == "" ||
                txtMKNV.Text.Trim() == "" ||
                txtTenNV.Text.Trim() == "" ||
                cbCVNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin bắt buộc.");
                return;
            }

            string gioiTinh = LayGioiTinh();

            bool kq = bll.ThemNhanVien(
                txtTKNV.Text.Trim(),
                txtMKNV.Text.Trim(),
                Convert.ToInt32(cbCVNV.SelectedValue),
                cbTrangThaiNV.Text,
                txtTenNV.Text.Trim(),
                txtCCCDNV.Text.Trim(),
                txtSDTNV.Text.Trim(),
                gioiTinh,
                txtDCNV.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                LoadDanhSachNhanVien();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (maNhanVien == 0 || maTaiKhoan == 0)
            {
                MessageBox.Show("Vui lòng double click vào danh sách để chọn nhân viên cần sửa.");
                return;
            }

            if (cbCVNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.");
                return;
            }

            string gioiTinh = LayGioiTinh();

            bool kq = bll.SuaNhanVien(
                maNhanVien,
                maTaiKhoan,
                txtTKNV.Text.Trim(),
                txtMKNV.Text.Trim(),
                Convert.ToInt32(cbCVNV.SelectedValue),
                cbTrangThaiNV.Text,
                txtTenNV.Text.Trim(),
                txtCCCDNV.Text.Trim(),
                txtSDTNV.Text.Trim(),
                gioiTinh,
                txtDCNV.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Sửa nhân viên thành công.");
                LoadDanhSachNhanVien();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDanhSachNhanVien();
            LamMoi();
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {
            dgvBangNV.DataSource = bll.TimNhanVien(txtTimNV.Text.Trim());
        }

        private void dgvBangNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBangNV.Rows[e.RowIndex];

            maNhanVien = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
            maTaiKhoan = Convert.ToInt32(row.Cells["MaTaiKhoan"].Value);

            txtTKNV.Text = row.Cells["TenDangNhap"].Value?.ToString();
            txtMKNV.Text = row.Cells["MatKhau"].Value?.ToString();
            txtTenNV.Text = row.Cells["HoTen"].Value?.ToString();
            txtCCCDNV.Text = row.Cells["CCCD"].Value?.ToString();
            txtSDTNV.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtDCNV.Text = row.Cells["DiaChi"].Value?.ToString();

            string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
            radNamNV.Checked = gioiTinh == "Nam";
            radNuNV.Checked = gioiTinh == "Nữ";

            cbTrangThaiNV.Text = row.Cells["TrangThai"].Value?.ToString();
            cbCVNV.SelectedValue = row.Cells["MaChucVu"].Value;

            lbl.Text = row.Cells["Luong"].Value?.ToString();
        }

        private void cbCVNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCVNV.SelectedItem is DataRowView drv)
            {
                lbl.Text = drv["Luong"].ToString();
            }
        }

        private void cbTrangThaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dgvBangNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void txtTimNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTKNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMKNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCCCDNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSDTNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void radNamNV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radNuNV_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtDCNV_TextChanged(object sender, EventArgs e)
        {
        }

        private void lbl_Click(object sender, EventArgs e)
        {
        }
    }
}