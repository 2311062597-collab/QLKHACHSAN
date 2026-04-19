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
    public partial class DangNhapForm : Form
    {
        public DangNhapForm()
        {
            InitializeComponent();
        }

        private void DangNhapForm_Load(object sender, EventArgs e)
        {
            // Xóa nội dung mặc định khi form load
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPassword.UseSystemPasswordChar = true;

            // Set focus vào txtUsername
            txtUsername.Focus();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào txtUsername
            if (txtUsername.Text == "Tên người dùng")
            {
                txtUsername.Text = string.Empty;
                txtUsername.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời khỏi txtUsername
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Tên người dùng";
                txtUsername.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào txtPassword
            if (txtPassword.Text == "Mật khẩu")
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = System.Drawing.Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời khỏi txtPassword
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Mật khẩu";
                txtPassword.ForeColor = System.Drawing.Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ TextBox
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra xem người dùng có nhập thông tin không
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

            // TODO: Thêm logic xác thực đăng nhập tại đây
            MessageBox.Show($"Đăng nhập với tài khoản: {username}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Xử lý sự kiện quên mật khẩu
            MessageBox.Show("Tính năng quên mật khẩu đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // TODO: Mở form reset mật khẩu
        }

        private void DangNhapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Xác nhận trước khi thoát ứng dụng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
