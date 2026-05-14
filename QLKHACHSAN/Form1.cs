using System;
using System.Windows.Forms;
using QLKHACHSAN.UI;

namespace QLKHACHSAN
{
    public partial class Form1 : Form
    {
        private Form currentChildForm;

        public Form1()
        {
            InitializeComponent();

            panel1.Dock = DockStyle.Left;

            // Gắn sự kiện Load
            this.Load += Form1_Load;
        }

        private void OpenChildForm(Form childForm)
        {
            pnlMain.SuspendLayout();

            try
            {
                if (currentChildForm != null)
                {
                    currentChildForm.Hide();
                    currentChildForm.Close();
                    currentChildForm.Dispose();
                }

                currentChildForm = childForm;

                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;

                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(childForm);
                pnlMain.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();
            }
            finally
            {
                pnlMain.ResumeLayout(true);
            }
        }

        private void ApplyPermission()
        {
            string chucVu = SessionManager.TenChucVu == null
                ? ""
                : SessionManager.TenChucVu.Trim().ToLower();

            // Mặc định khóa hết chức năng
            btnDatPhong.Enabled = false;        // Đặt phòng
            btnMuaDV.Enabled = false;       // Mua dịch vụ
            btnPhong.Enabled = false;       // Phòng
            btnDichVu.Enabled = false;      // Dịch vụ
            btnKH.Enabled = false;          // Khách hàng
            btnNV.Enabled = false;          // Nhân viên
            btnThongKe.Enabled = false;     // Thống kê
            btnTk.Enabled = false;          // Tài khoản

            // Nếu có button9 cũng là Tài khoản thì khóa luôn
            button9.Enabled = false;

            // ADMIN: được vào tất cả
            if (chucVu.Contains("admin"))
            {
                btnDatPhong.Enabled = true;
                btnMuaDV.Enabled = true;
                btnPhong.Enabled = true;
                btnDichVu.Enabled = true;
                btnKH.Enabled = true;
                btnNV.Enabled = true;
                btnThongKe.Enabled = true;
                btnTk.Enabled = true;
                button9.Enabled = true;
            }
            // LỄ TÂN: đặt phòng, mua dịch vụ, phòng, khách hàng
            else if (chucVu.Contains("lễ tân") || chucVu.Contains("le tan"))
            {
                btnDatPhong.Enabled = true;
                btnMuaDV.Enabled = true;
                btnPhong.Enabled = true;
                btnKH.Enabled = true;

                // Nếu muốn lễ tân được xem tài khoản cá nhân thì bật dòng này
                btnTk.Enabled = true;
                button9.Enabled = true;
            }
            // KẾ TOÁN / KẾT TOÁN: mua dịch vụ, khách hàng, thống kê
            else if (chucVu.Contains("kế toán") ||
                     chucVu.Contains("ke toan") ||
                     chucVu.Contains("kết toán") ||
                     chucVu.Contains("ket toan"))
            {
                btnMuaDV.Enabled = false;
                btnKH.Enabled = true;
                btnThongKe.Enabled = true;

                // Nếu muốn kế toán được xem tài khoản cá nhân thì bật dòng này
                btnTk.Enabled = true;
                button9.Enabled = true;
            }
            else
            {
                MessageBox.Show(
                    "Chức vụ của tài khoản này chưa được phân quyền!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void OpenDefaultFormByRole()
        {
            string chucVu = SessionManager.TenChucVu == null
                ? ""
                : SessionManager.TenChucVu.Trim().ToLower();

            if (chucVu.Contains("admin"))
            {
                OpenChildForm(new TaiKhoanForm(SessionManager.MaTaiKhoan));
            }
            else if (chucVu.Contains("lễ tân") || chucVu.Contains("le tan"))
            {
                OpenChildForm(new DatPhongForm());
            }
            else if (chucVu.Contains("kế toán") ||
                     chucVu.Contains("ke toan") ||
                     chucVu.Contains("kết toán") ||
                     chucVu.Contains("ket toan"))
            {
                OpenChildForm(new ThongKeForm());
            }
            else
            {
                pnlMain.Controls.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                ApplyPermission();
                OpenDefaultFormByRole();
            }
            else
            {
                MessageBox.Show(
                    "Lỗi: Không tìm thấy thông tin người dùng!",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                this.Close();
            }
        }

        private bool IsAdmin()
        {
            string chucVu = SessionManager.TenChucVu == null
                ? ""
                : SessionManager.TenChucVu.Trim().ToLower();

            return chucVu.Contains("admin");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DatPhongForm());
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                OpenChildForm(new TaiKhoanForm(SessionManager.MaTaiKhoan));
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            if (SessionManager.IsLoggedIn())
            {
                OpenChildForm(new TaiKhoanForm(SessionManager.MaTaiKhoan));
            }
            else
            {
                MessageBox.Show("Vui lòng đăng nhập trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMuaDV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MuaDichVuForm());
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhongForm());
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DichVuForm());
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new KhachHangForm());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng Nhân viên!",
                    "Không có quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            OpenChildForm(new NhanVienForm());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ThongKeForm());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
               "Bạn có chắc muốn đăng xuất?",
               "Thông báo",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                SessionManager.Clear();

                this.Hide();
                DangNhapForm dn = new DangNhapForm();
                dn.Show();
            }
        }
    }
}