using QLKHACHSAN.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLKHACHSAN.UI
{
    public partial class KhachHangForm : Form
    {
        private KhachHangBLL bll = new KhachHangBLL();
        private int maKH = 0;

        public KhachHangForm()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.KhachHangForm_Load);
            this.dgvKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellDoubleClick);

            txtSDTKH.KeyPress += txtSDTKH_KeyPress;
            txtCCCDKH.KeyPress += txtCCCDKH_KeyPress;

            txtSDTKH.MaxLength = 10;
            txtCCCDKH.MaxLength = 12;
        }

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            LoadData();
            ClearForm();
        }

        private void LoadData()
        {
            dgvKH.AutoGenerateColumns = true;
            dgvKH.DataSource = null;
            dgvKH.DataSource = bll.GetAll();
            dgvKH.Refresh();

            if (dgvKH.Columns.Contains("MaKhachHang"))
                dgvKH.Columns["MaKhachHang"].Visible = false;
        }

        private void ClearForm()
        {
            maKH = 0;
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtCCCDKH.Clear();
            txtTimKH.Clear();
        }

        private void txtSDTKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCCCDKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool KiemTraHopLe()
        {
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                txtTenKH.Focus();
                return false;
            }

            if (txtSDTKH.Text.Trim() != "" && !txtSDTKH.Text.All(char.IsDigit))
            {
                MessageBox.Show("SĐT chỉ được nhập số");
                txtSDTKH.Focus();
                return false;
            }

            if (txtCCCDKH.Text.Trim() != "" && !txtCCCDKH.Text.All(char.IsDigit))
            {
                MessageBox.Show("CCCD chỉ được nhập số");
                txtCCCDKH.Focus();
                return false;
            }

            if (txtSDTKH.Text.Trim() != "" && txtSDTKH.Text.Length != 10)
            {
                MessageBox.Show("SĐT phải đủ 10 số");
                txtSDTKH.Focus();
                return false;
            }

            if (txtCCCDKH.Text.Trim() != "" && txtCCCDKH.Text.Length != 12)
            {
                MessageBox.Show("CCCD phải đủ 12 số");
                txtCCCDKH.Focus();
                return false;
            }

            return true;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            bool kq = bll.Them(
                txtTenKH.Text.Trim(),
                txtSDTKH.Text.Trim(),
                txtCCCDKH.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Thêm khách hàng thành công");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại (có thể trùng CCCD)");
            }
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            dgvKH.DataSource = bll.Tim(txtTimKH.Text.Trim());
        }

        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (maKH == 0)
            {
                MessageBox.Show("Chọn khách hàng để sửa!");
                return;
            }

            if (!KiemTraHopLe()) return;

            bool kq = bll.Sua(
                maKH,
                txtTenKH.Text.Trim(),
                txtSDTKH.Text.Trim(),
                txtCCCDKH.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Sửa thành công");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvKH.Rows[e.RowIndex];

            maKH = Convert.ToInt32(row.Cells["MaKhachHang"].Value);

            txtTenKH.Text = row.Cells["HoTen"].Value?.ToString();
            txtSDTKH.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtCCCDKH.Text = row.Cells["CCCD"].Value?.ToString();
        }

        private void txtTimKH_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSDTKH_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCCCDKH_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}