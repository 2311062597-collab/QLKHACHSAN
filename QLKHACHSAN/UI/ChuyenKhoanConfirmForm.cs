using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace QLKHACHSAN.UI
{
    public partial class ChuyenKhoanConfirmForm : Form
    {
        private readonly decimal soTien;
        private readonly string noiDungChuyenKhoan;

        public ChuyenKhoanConfirmForm(decimal soTien, string noiDungChuyenKhoan)
        {
            InitializeComponent();

            this.soTien = soTien;
            this.noiDungChuyenKhoan = noiDungChuyenKhoan;

            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Xác nhận chuyển khoản";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;

            LoadThongTinChuyenKhoan();
            LoadVietQrTheoSoTien();
        }

        private void LoadThongTinChuyenKhoan()
        {
            lblThongTin.Text =
                "THÔNG TIN CHUYỂN KHOẢN\n\n" +
                "Ngân hàng: BIDV - PGD Vân Trì\n" +
                "Chủ tài khoản: NGUYEN MAU HAI\n" +
                "Số tài khoản: 2143312836\n" +
                "Số tiền: " + soTien.ToString("N0") + " đ\n" +
                "Nội dung CK: " + noiDungChuyenKhoan + "\n\n" +
                "Khách quét mã QR để chuyển khoản.\n" +
                "Sau khi nhận tiền, bấm Xác nhận thanh toán thành công.";
        }

        private void LoadVietQrTheoSoTien()
        {
            try
            {
                string bankId = "970418";
                string accountNo = "2143312836";
                string template = "compact2";

                int amount = Convert.ToInt32(soTien);

                string addInfo = Uri.EscapeDataString(noiDungChuyenKhoan);
                string accountName = Uri.EscapeDataString("NGUYEN MAU HAI");

                string url =
                    "https://img.vietqr.io/image/" +
                    bankId + "-" + accountNo + "-" + template + ".png" +
                    "?amount=" + amount +
                    "&addInfo=" + addInfo +
                    "&accountName=" + accountName;

                using (WebClient client = new WebClient())
                {
                    byte[] data = client.DownloadData(url);

                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data))
                    {
                        picQRCode.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tạo được mã QR chuyển khoản.\n" + ex.Message,
                    "Lỗi QR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ChuyenKhoanConfirmForm_Load(object sender, EventArgs e)
        {
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