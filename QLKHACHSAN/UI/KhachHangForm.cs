using QLKHACHSAN.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKHACHSAN.UI
{
    public partial class KhachHangForm : Form
    {
        KhachHangBLL bll = new KhachHangBLL();
        int maKH = 0;

        public KhachHangForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.KhachHangForm_Load);
            this.dgvKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellDoubleClick);
        }

        private void KhachHangForm_Load(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();
        }

        void LoadData()
        {
            dgvKH.DataSource = bll.GetAll();

            if (dgvKH.Columns.Contains("MaKhachHang"))
                dgvKH.Columns["MaKhachHang"].Visible = false;
        }

        void ClearForm()
        {
            maKH = 0;
            txtTenKH.Clear();
            txtSDTKH.Clear();
            txtCCCDKH.Clear();
            txtTimKH.Clear();
        }

        // ➕ THÊM
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            // Validate
            if (txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                return;
            }

            // Gọi BLL
            bool kq = bll.Them(
                txtTenKH.Text.Trim(),
                txtSDTKH.Text.Trim(),
                txtCCCDKH.Text.Trim()
            );

            if (kq)
            {
                MessageBox.Show("Thêm khách hàng thành công");

                dgvKH.DataSource = bll.GetAll(); // reload data
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm thất bại (có thể trùng CCCD)");
            }
        }

        // 🔍 TÌM
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            dgvKH.DataSource = bll.Tim(txtTimKH.Text.Trim());
        }

        // 🔄 REFRESH
        private void btnRefreshKH_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearForm();

        }

        // ✏️ SỬA
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (maKH == 0)
            {
                MessageBox.Show("Chọn khách hàng để sửa!");
                return;
            }

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

        // 🖱 DOUBLE CLICK
        private void dgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKH.Rows[e.RowIndex];

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
