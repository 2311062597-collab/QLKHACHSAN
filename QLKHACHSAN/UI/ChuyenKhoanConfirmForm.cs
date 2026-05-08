using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLKHACHSAN.UI
{
    public partial class ChuyenKhoanConfirmForm : Form
    {
        public ChuyenKhoanConfirmForm(decimal soTien, string noiDungChuyenKhoan)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Xác nhận chuyển khoản";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            if (picQRCode != null)
            {
                picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            }

            lblThongTin.Text =
                "THÔNG TIN CHUYỂN KHOẢN\n\n" +
                "Ngân hàng: BIDV - PGD Vân Trì\n" +
                "Chủ tài khoản: NGUYEN MAU HAI\n" +
                "Số tài khoản: 2143312836\n" +
                "Số tiền: " + soTien.ToString("N0") + " đ\n" +
                "Nội dung CK: " + noiDungChuyenKhoan + "\n\n" +
                "Sau khi khách đã chuyển khoản,\n" +
                "bấm Xác nhận thanh toán thành công.";

            btnXacNhan.Click -= btnXacNhan_Click;
            btnXacNhan.Click += btnXacNhan_Click;

            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;
        }

        private void ChuyenKhoanConfirmForm_Load(object sender, EventArgs e)
        {
            // Để trống cũng được.
            // Hàm này cần có nếu Designer.cs đang gắn sự kiện Load.
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}