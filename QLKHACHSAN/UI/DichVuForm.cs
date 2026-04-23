using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class DichVuForm : Form
    {
        private DichVuBLL bll = new DichVuBLL();
        private int maDichVu = 0;
        private int maLoaiDichVu = 0;

        public DichVuForm()
        {
            InitializeComponent();
        }

        private void DichVuForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            LoadTrangThai();
            LoadLoaiDichVuComboBox();
            LoadDanhSachDichVu();
            LamMoi();
        }

        private void LoadDanhSachDichVu()
        {
            dgvDV.DataSource = bll.GetDanhSachDichVu();

            if (dgvDV.Columns.Contains("MaDichVu"))
                dgvDV.Columns["MaDichVu"].Visible = false;

            if (dgvDV.Columns.Contains("MaLoaiDichVu"))
                dgvDV.Columns["MaLoaiDichVu"].Visible = false;
        }

        private void LoadLoaiDichVuComboBox()
        {
            DataTable dt = bll.GetLoaiDichVu();
            cbDichVuloai.DataSource = dt;
            cbDichVuloai.DisplayMember = "TenLoaiDichVu";
            cbDichVuloai.ValueMember = "MaLoaiDichVu";
            cbDichVuloai.SelectedIndex = -1;
        }

        private void LoadTrangThai()
        {
            cbTrangThaiDv.Items.Clear();
            cbTrangThaiDv.Items.Add("Đang hoạt động");
            cbTrangThaiDv.Items.Add("Tạm dừng");
            cbTrangThaiDv.Items.Add("Không hoạt động");
            cbTrangThaiDv.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThaiDv.SelectedIndex = 0;
        }

        private void LamMoi()
        {
            maDichVu = 0;
            maLoaiDichVu = 0;

            txtTimDV.Clear();
            txtTenDV.Clear();
            txtDonGia.Clear();
            txtMoTaDV.Clear();

            cbTrangThaiDv.SelectedIndex = 0;
            cbDichVuloai.SelectedIndex = -1;
        }

        private void btnTimDV_Click(object sender, EventArgs e)
        {
            dgvDV.DataSource = bll.TimDichVu(txtTimDV.Text.Trim());
        }

        private void btnRefreshDV_Click(object sender, EventArgs e)
        {
            LoadLoaiDichVuComboBox();
            LoadDanhSachDichVu();
            LamMoi();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (txtTenDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.");
                txtTenDV.Focus();
                return;
            }

            if (cbDichVuloai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ.");
                cbDichVuloai.Focus();
                return;
            }

            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đơn giá.");
                txtDonGia.Focus();
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                txtDonGia.Focus();
                return;
            }

            bool kq = bll.ThemDichVu(
                txtTenDV.Text.Trim(),
                Convert.ToInt32(cbDichVuloai.SelectedValue),
                donGia,
                txtMoTaDV.Text.Trim(),
                cbTrangThaiDv.Text
            );

            if (kq)
            {
                MessageBox.Show("Thêm dịch vụ thành công.");
                LoadDanhSachDichVu();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại.");
            }
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (maDichVu == 0)
            {
                MessageBox.Show("Vui lòng double click chọn dịch vụ cần sửa.");
                return;
            }

            if (txtTenDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.");
                return;
            }

            if (cbDichVuloai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ.");
                return;
            }

            decimal donGia;
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            bool kq = bll.SuaDichVu(
                maDichVu,
                txtTenDV.Text.Trim(),
                Convert.ToInt32(cbDichVuloai.SelectedValue),
                donGia,
                txtMoTaDV.Text.Trim(),
                cbTrangThaiDv.Text
            );

            if (kq)
            {
                MessageBox.Show("Sửa dịch vụ thành công.");
                LoadDanhSachDichVu();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa dịch vụ thất bại.");
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (maDichVu == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa dịch vụ này?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                bool kq = bll.XoaDichVu(maDichVu);

                if (kq)
                {
                    MessageBox.Show("Xóa dịch vụ thành công.");
                    LoadDanhSachDichVu();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại. Có thể dịch vụ đã được sử dụng ở bảng khác.");
                }
            }
        }

        private void dgvDV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDV.Rows[e.RowIndex];

            maDichVu = Convert.ToInt32(row.Cells["MaDichVu"].Value);
            maLoaiDichVu = Convert.ToInt32(row.Cells["MaLoaiDichVu"].Value);

            txtTenDV.Text = row.Cells["TenDichVu"].Value?.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
            txtMoTaDV.Text = row.Cells["MoTa"].Value?.ToString();
            cbTrangThaiDv.Text = row.Cells["TrangThai"].Value?.ToString();
            cbDichVuloai.SelectedValue = maLoaiDichVu;
        }

     

        private void txtTimDV_TextChanged(object sender, EventArgs e) { }
        private void txtTenDV_TextChanged(object sender, EventArgs e) { }
        private void txtDonGia_TextChanged(object sender, EventArgs e) { }
        private void cbDichVuloai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbTrangThaiDv_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtMoTaDV_TextChanged(object sender, EventArgs e) { }
        private void dgvDV_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            LoaiDichVuForm f = new LoaiDichVuForm();
            f.ShowDialog();

            LoadLoaiDichVuComboBox();
            LoadDanhSachDichVu();

        }
    }
}