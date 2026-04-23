using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class LoaiDichVuForm : Form
    {
        private LoaiDichVuBLL bll = new LoaiDichVuBLL();
        private int maLoaiDichVu = 0;

        public LoaiDichVuForm()
        {
            InitializeComponent();
            this.Load += LoaiDichVuForm_Load;
            this.Shown += LoaiDichVuForm_Shown;
        }

        private void LoaiDichVuForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            dgvLoaiDV.AutoGenerateColumns = true;
        }

        private void LoaiDichVuForm_Shown(object sender, EventArgs e)
        {
            LoadDanhSachLoaiDichVu();
            LamMoi();
        }

        private void LoadDanhSachLoaiDichVu()
        {
            DataTable dt = bll.GetDanhSachLoaiDichVu();

            dgvLoaiDV.DataSource = null;
            dgvLoaiDV.AutoGenerateColumns = true;
            dgvLoaiDV.DataSource = dt;
            dgvLoaiDV.Refresh();

            if (dgvLoaiDV.Columns.Contains("MaLoaiDichVu"))
                dgvLoaiDV.Columns["MaLoaiDichVu"].Visible = false;
        }

        private void LamMoi()
        {
            maLoaiDichVu = 0;
            txtTimLoaiDV.Clear();
            txtTenLoaiDV.Clear();
            txtDVtinh.Clear();
        }

        private void btnTimLoaiDV_Click(object sender, EventArgs e)
        {
            dgvLoaiDV.DataSource = bll.TimLoaiDichVu(txtTimLoaiDV.Text.Trim());
        }

        private void btnThemLoaiDV_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại dịch vụ.");
                txtTenLoaiDV.Focus();
                return;
            }

            if (bll.KiemTraLoaiDichVuTonTai(txtTenLoaiDV.Text.Trim()))
            {
                MessageBox.Show("Loại dịch vụ đã tồn tại.");
                txtTenLoaiDV.Focus();
                return;
            }

            bool kq = bll.ThemLoaiDichVu(
                txtTenLoaiDV.Text.Trim(),
                txtDVtinh.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Thêm loại dịch vụ thành công.");
                LoadDanhSachLoaiDichVu();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Thêm loại dịch vụ thất bại.");
            }
        }

        private void btnSuaLoaiDV_Click(object sender, EventArgs e)
        {
            if (maLoaiDichVu == 0)
            {
                MessageBox.Show("Vui lòng double click chọn loại dịch vụ cần sửa.");
                return;
            }

            if (txtTenLoaiDV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại dịch vụ.");
                return;
            }

            bool kq = bll.SuaLoaiDichVu(
                maLoaiDichVu,
                txtTenLoaiDV.Text.Trim(),
                txtDVtinh.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Sửa loại dịch vụ thành công.");
                LoadDanhSachLoaiDichVu();
                LamMoi();
            }
            else
            {
                MessageBox.Show("Sửa loại dịch vụ thất bại.");
            }
        }

        private void btnXoaLoaiDV_Click(object sender, EventArgs e)
        {
            if (maLoaiDichVu == 0)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ cần xóa.");
                return;
            }

            if (bll.LoaiDichVuDangDuocKhachSuDung(maLoaiDichVu))
            {
                MessageBox.Show("Không thể xóa loại dịch vụ vì đang có khách sử dụng.");
                return;
            }

            if (bll.LoaiDichVuConDichVu(maLoaiDichVu))
            {
                MessageBox.Show("Không thể xóa loại dịch vụ vì vẫn còn dịch vụ thuộc loại này.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa loại dịch vụ này?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                bool kq = bll.XoaLoaiDichVu(maLoaiDichVu);

                if (kq)
                {
                    MessageBox.Show("Xóa loại dịch vụ thành công.");
                    LoadDanhSachLoaiDichVu();
                    LamMoi();
                }
                else
                {
                    MessageBox.Show("Xóa loại dịch vụ thất bại.");
                }
            }
        }

        private void btnRefreshLoaiDV_Click(object sender, EventArgs e)
        {
            LoadDanhSachLoaiDichVu();
            LamMoi();
        }

        private void dgvLoaiDV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoaiDV.Rows[e.RowIndex];

            maLoaiDichVu = Convert.ToInt32(row.Cells["MaLoaiDichVu"].Value);
            txtTenLoaiDV.Text = row.Cells["TenLoaiDichVu"].Value?.ToString();
            txtDVtinh.Text = row.Cells["DonViTinh"].Value?.ToString();
        }

        private void txtTimLoaiDV_TextChanged(object sender, EventArgs e) { }
        private void txtTenLoaiDV_TextChanged(object sender, EventArgs e) { }
        private void txtDVtinh_TextChanged(object sender, EventArgs e) { }
        private void dgvLoaiDV_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}