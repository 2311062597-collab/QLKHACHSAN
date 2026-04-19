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
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoanForm());
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
            OpenChildForm(new TaiKhoanForm());
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TaiKhoanForm());
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
                this.Hide();
                DangNhapForm dn = new DangNhapForm();
                dn.Show();
            }
        }
    }
}