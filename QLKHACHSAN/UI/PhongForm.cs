using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class PhongForm : Form
    {
        private PhongBLL bll = new PhongBLL();
        private int maPhong = 0;

        public PhongForm()
        {
            InitializeComponent();
            this.Load += PhongForm_Load;
            this.dgvBangPhong.CellClick += dgvBangPhong_CellClick;
        }

        private void PhongForm_Load(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
            LoadTang();
            LoadTrangThai();
            LoadLoaiPhong();
            LoadData();
            ClearForm();
        }

        private void LoadData()
        {
            dgvBangPhong.AutoGenerateColumns = true;
            dgvBangPhong.DataSource = null;
            dgvBangPhong.DataSource = bll.GetDanhSachPhong();

            if (dgvBangPhong.Columns.Contains("MaPhong"))
                dgvBangPhong.Columns["MaPhong"].Visible = false;

            if (dgvBangPhong.Columns.Contains("MaLoaiPhong"))
                dgvBangPhong.Columns["MaLoaiPhong"].Visible = false;
        }

        private void LoadTang()
        {
            cbTang.Items.Clear();
            cbLocTang.Items.Clear();

            cbLocTang.Items.Add("");
            for (int i = 1; i <= 9; i++)
            {
                cbTang.Items.Add(i.ToString());
                cbLocTang.Items.Add(i.ToString());
            }

            cbTang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLocTang.DropDownStyle = ComboBoxStyle.DropDownList;

            cbTang.SelectedIndex = -1;
            cbLocTang.SelectedIndex = 0;
        }

        private void LoadTrangThai()
        {
            cbTrangThaiPhong.Items.Clear();
            cbTrangThaiPhong.Items.Add("Còn trống");
            cbTrangThaiPhong.Items.Add("Đang sử dụng");
            cbTrangThaiPhong.Items.Add("Bảo trì");
            cbTrangThaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTrangThaiPhong.SelectedIndex = 0;
        }

        private void LoadLoaiPhong()
        {
            DataTable dt = bll.GetLoaiPhong();

            cbLoaiPhong.DataSource = dt.Copy();
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbLoaiPhong.SelectedIndex = -1;

            DataTable dtLoc = dt.Copy();
            DataRow row = dtLoc.NewRow();
            row["MaLoaiPhong"] = DBNull.Value;
            row["TenLoaiPhong"] = "";
            row["Gia"] = DBNull.Value;
            row["MoTa"] = DBNull.Value;
            dtLoc.Rows.InsertAt(row, 0);

            cblocLoaiPhong.DataSource = dtLoc;
            cblocLoaiPhong.DisplayMember = "TenLoaiPhong";
            cblocLoaiPhong.ValueMember = "MaLoaiPhong";
            cblocLoaiPhong.SelectedIndex = 0;
        }

        private void ClearForm()
        {
            maPhong = 0;
            txtTimPhong.Clear();
            txtSoPhong.Clear();
            cbTang.SelectedIndex = -1;
            cbLoaiPhong.SelectedIndex = -1;
            cbTrangThaiPhong.SelectedIndex = 0;
            blGia.Text = "";
            lblmotaLoaiPhong.Text = "";
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            string tang = cbLocTang.Text;
            string maLoaiPhong = "";

            if (cblocLoaiPhong.SelectedValue != null && cblocLoaiPhong.SelectedIndex > 0)
                maLoaiPhong = cblocLoaiPhong.SelectedValue.ToString();

            dgvBangPhong.DataSource = bll.TimPhong(
                txtTimPhong.Text.Trim(),
                tang,
                maLoaiPhong
            );
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiPhong.SelectedItem is DataRowView drv)
            {
                blGia.Text = drv["Gia"]?.ToString();
                lblmotaLoaiPhong.Text = drv["MoTa"]?.ToString();
            }
        }

        private void btnqlLoaiPhong_Click(object sender, EventArgs e)
        {
            LoaiPhongForm f = new LoaiPhongForm();
            f.ShowDialog();
            LoadLoaiPhong();
            LoadData();
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtSoPhong.Text.Trim() == "" || cbTang.SelectedIndex == -1 || cbLoaiPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin phòng.");
                return;
            }

            bool kq = bll.ThemPhong(
                txtSoPhong.Text.Trim(),
                Convert.ToInt32(cbTang.Text),
                Convert.ToInt32(cbLoaiPhong.SelectedValue),
                cbTrangThaiPhong.Text
            );

            if (kq)
            {
                MessageBox.Show("Thêm phòng thành công.");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Thêm phòng thất bại.");
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (maPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa.");
                return;
            }

            if (txtSoPhong.Text.Trim() == "" || cbTang.SelectedIndex == -1 || cbLoaiPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin phòng.");
                return;
            }

            bool kq = bll.SuaPhong(
                maPhong,
                txtSoPhong.Text.Trim(),
                Convert.ToInt32(cbTang.Text),
                Convert.ToInt32(cbLoaiPhong.SelectedValue),
                cbTrangThaiPhong.Text
            );

            if (kq)
            {
                MessageBox.Show("Sửa phòng thành công.");
                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Sửa phòng thất bại.");
            }
        }

        private void btnRefreshPhong_Click(object sender, EventArgs e)
        {
            LoadLoaiPhong();
            LoadData();
            ClearForm();
        }

        private void dgvBangPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBangPhong.Rows[e.RowIndex];

            maPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
            txtSoPhong.Text = row.Cells["SoPhong"].Value?.ToString();
            cbTang.Text = row.Cells["Tang"].Value?.ToString();
            cbTrangThaiPhong.Text = row.Cells["TrangThai"].Value?.ToString();
            cbLoaiPhong.SelectedValue = row.Cells["MaLoaiPhong"].Value;

            blGia.Text = row.Cells["Gia"].Value?.ToString();
            lblmotaLoaiPhong.Text = row.Cells["MoTa"].Value?.ToString();
        }

        private void txtTimPhong_TextChanged(object sender, EventArgs e) { }
        private void cbLocTang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cblocLoaiPhong_SelectedIndexChanged(object sender, EventArgs e) { }
        private void blGia_Click(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void txtSoPhong_TextChanged(object sender, EventArgs e) { }
        private void cbTang_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cbTrangThaiPhong_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblmotaLoaiPhong_Click(object sender, EventArgs e) { }
        private void dgvBangPhong_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void PhongForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}