using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class LoaiPhongForm : Form
    {
        private LoaiPhongBLL bll = new LoaiPhongBLL();
        private int maLoaiPhong = 0;

        public LoaiPhongForm()
        {
            InitializeComponent();
            this.Load += LoaiPhongForm_Load;
            this.dgvLoaiPhong.CellClick += dgvLoaiPhong_CellClick;
        }

        private void LoaiPhongForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            LoadData();
            ClearForm();
        }

        private void LoadData()
        {
            dgvLoaiPhong.AutoGenerateColumns = true;
            dgvLoaiPhong.DataSource = null;
            dgvLoaiPhong.DataSource = bll.GetDanhSachLoaiPhong();

            if (dgvLoaiPhong.Columns.Contains("MaLoaiPhong"))
                dgvLoaiPhong.Columns["MaLoaiPhong"].Visible = false;
        }

        private void ClearForm()
        {
            maLoaiPhong = 0;
            txtTimLoaiPhong.Clear();
            txtTenLoaiPhong.Clear();
            txtGia.Clear();
            txtMoTaLoaiPhong.Clear();
        }

        private void btnThemLoaiPhong_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiPhong.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng.");
                return;
            }

            decimal gia;
            if (!decimal.TryParse(txtGia.Text.Trim(), out gia))
            {
                MessageBox.Show("Giá không hợp lệ.");
                txtGia.Focus();
                return;
            }

            if (bll.KiemTraLoaiPhongTonTai(txtTenLoaiPhong.Text.Trim()))
            {
                MessageBox.Show("Loại phòng đã tồn tại.");
                return;
            }

            bool kq = bll.ThemLoaiPhong(
                txtTenLoaiPhong.Text.Trim(),
                gia,
                txtMoTaLoaiPhong.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Thêm loại phòng thành công.");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm loại phòng thất bại.");
            }
        }

        private void btnSuaLoaiPhong_Click(object sender, EventArgs e)
        {
            if (maLoaiPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa.");
                return;
            }

            decimal gia;
            if (!decimal.TryParse(txtGia.Text.Trim(), out gia))
            {
                MessageBox.Show("Giá không hợp lệ.");
                txtGia.Focus();
                return;
            }

            bool kq = bll.SuaLoaiPhong(
                maLoaiPhong,
                txtTenLoaiPhong.Text.Trim(),
                gia,
                txtMoTaLoaiPhong.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Sửa loại phòng thành công.");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Sửa loại phòng thất bại.");
            }
        }

        private void btnXoaLoaiPhong_Click(object sender, EventArgs e)
        {
            if (maLoaiPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa.");
                return;
            }

            if (bll.LoaiPhongDangDuocSuDung(maLoaiPhong))
            {
                MessageBox.Show("Không thể xóa loại phòng vì đang có phòng sử dụng.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa loại phòng này?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                bool kq = bll.XoaLoaiPhong(maLoaiPhong);

                if (kq)
                {
                    MessageBox.Show("Xóa loại phòng thành công.");
                    LoadData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Xóa loại phòng thất bại.");
                }
            }
        }

        private void btnRefreshLoaiPhong_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void btnTimLoaiPhong_Click(object sender, EventArgs e)
        {
            dgvLoaiPhong.DataSource = bll.TimLoaiPhong(txtTimLoaiPhong.Text.Trim());
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

            maLoaiPhong = Convert.ToInt32(row.Cells["MaLoaiPhong"].Value);
            txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value?.ToString();
            txtGia.Text = row.Cells["Gia"].Value?.ToString();
            txtMoTaLoaiPhong.Text = row.Cells["MoTa"].Value?.ToString();
        }

        private void txtTimLoaiPhong_TextChanged(object sender, EventArgs e) { }
        private void txtTenLoaiPhong_TextChanged(object sender, EventArgs e) { }
        private void txtGia_TextChanged(object sender, EventArgs e) { }
        private void txtMoTaLoaiPhong_TextChanged(object sender, EventArgs e) { }
        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}