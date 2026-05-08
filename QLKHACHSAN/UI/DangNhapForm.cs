using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class DangNhapForm : Form
    {
        private DangNhapBLL bll = new DangNhapBLL();

        public DangNhapForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1000, 650);

            panelRight.Dock = DockStyle.Fill;
            panelRight.BackgroundImageLayout = ImageLayout.Stretch;

            groupLogin.Anchor = AnchorStyles.None;

            this.Resize += DangNhapForm_Resize;
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

            txtUsername.ForeColor = Color.Black;
            txtPassword.ForeColor = Color.Black;
            txtPassword.UseSystemPasswordChar = true;

            // Làm đẹp GroupBox
            groupLogin.BackColor = Color.Transparent;

            // Làm đẹp nút đăng nhập
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.BackColor = Color.FromArgb(30, 144, 255);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Font = new Font(btnDangNhap.Font, FontStyle.Bold);

            CenterLoginBox();

            txtUsername.Focus();
        }

        private void DangNhapForm_Resize(object sender, EventArgs e)
        {
            CenterLoginBox();
        }

        private void CenterLoginBox()
        {
            groupLogin.Left = (panelRight.ClientSize.Width - groupLogin.Width) / 2;
            groupLogin.Top = (panelRight.ClientSize.Height - groupLogin.Height) / 2;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Tên người dùng")
            {
                txtUsername.Text = string.Empty;
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Tên người dùng";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Mật khẩu";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "Tên người dùng" || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (password == "Mật khẩu" || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            DataTable dt = bll.KiemTraDangNhap(username, password);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string trangThai = dt.Rows[0]["TrangThai"].ToString();

            if (trangThai == "Đã khóa")
            {
                MessageBox.Show("Tài khoản này đã bị khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();

            SessionManager.MaTaiKhoan = Convert.ToInt32(dt.Rows[0]["MaTaiKhoan"]);
            SessionManager.TenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            SessionManager.TenChucVu = dt.Rows[0]["TenChucVu"] != DBNull.Value
                ? dt.Rows[0]["TenChucVu"].ToString()
                : "";
            SessionManager.TrangThai = trangThai;

            System.Diagnostics.Debug.WriteLine($"[DangNhapForm] Session saved: MaTaiKhoan={SessionManager.MaTaiKhoan}, Username={SessionManager.TenDangNhap}");

            Form1 frm = new Form1();
            frm.ShowDialog();

            SessionManager.Clear();
            this.Show();
        }

        private void lnkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Tính năng quên mật khẩu đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DangNhapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát ứng dụng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void picBanner_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}