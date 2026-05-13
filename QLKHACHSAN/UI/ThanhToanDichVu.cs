using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKHACHSAN.BLL;
using QLKHACHSAN.DAL;
using System.Net;
using System.IO;
using System.Drawing.Printing;
namespace QLKHACHSAN.UI


{
    public partial class ThanhToanDichVuForm : Form
    {
        private string maKhachHang = string.Empty;
        private string tenKhachHang = string.Empty;
        private string tenDichVu = string.Empty;
        private int soLuong = 0;
        private decimal thanhTien = 0;
        private string phuongThuc = string.Empty;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private string TaoNoiDungChuyenKhoan()
        {
            return "TTDV" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void LoadVietQR(decimal soTien, string noiDungChuyenKhoan)
        {
            try
            {
                string bankId = "970418"; // BIDV
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

                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        picQRCode.Image = Image.FromStream(ms);
                        picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
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
        public ThanhToanDichVuForm()
        {
            InitializeComponent();

            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        /// <summary>
        /// Set payment information to display
        /// </summary>
        public void SetPaymentInfo(string customerName, string serviceName, int quantity, decimal amount, string paymentMethod, string customerId = "")
        {
            this.tenKhachHang = customerName;
            this.tenDichVu = serviceName;
            this.soLuong = quantity;
            this.thanhTien = amount;
            this.phuongThuc = paymentMethod;
            this.maKhachHang = customerId;
        }


        /// <summary>
        /// Load payment information to form controls
        /// </summary>
        private void LoadPaymentInfo()
        {
            try
            {
                lblCustomerNameValue.Text = tenKhachHang;
                lblServiceNameValue.Text = tenDichVu;
                lblQuantityValue.Text = soLuong.ToString();
                lblAmountValue.Text = FormatCurrency(thanhTien);
                lblPaymentMethodValue.Text = phuongThuc;

                // Show QR code if payment method is bank transfer
                if (phuongThuc.Trim().ToLower().Contains("chuyển khoản"))
                {
                    lblQRCode.Visible = true;
                    picQRCode.Visible = true;

                    string noiDungCK = TaoNoiDungChuyenKhoan();
                    LoadVietQR(thanhTien, noiDungCK);
                }
                else
                {
                    lblQRCode.Visible = false;
                    picQRCode.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Format currency with Vietnamese format
        /// </summary>
        private string FormatCurrency(decimal value)
        {
            return value.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }

        /// <summary>
        /// Generate QR code for bank transfer
        /// </summary>
        
        /// <summary>
        /// Handle form load
        /// </summary>
        private void ThanhToanDichVuForm_Load(object sender, EventArgs e)
        {
            LoadPaymentInfo();
        }

        /// <summary>
        /// Handle confirm button click
        /// </summary>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 13, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11, FontStyle.Regular);
            Font boldFont = new Font("Arial", 11, FontStyle.Bold);

            float y = 40;
            float left = 60;
            float lineHeight = 28;

            e.Graphics.DrawString("TAKIVIVU HOTEL", titleFont, Brushes.Black, left + 210, y);
            y += 40;

            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN DỊCH VỤ", headerFont, Brushes.Black, left + 150, y);
            y += 40;

            e.Graphics.DrawString("Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Tên khách hàng: " + lblCustomerNameValue.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Tên dịch vụ: " + lblServiceNameValue.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Số lượng: " + lblQuantityValue.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Phương thức thanh toán: " + lblPaymentMethodValue.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 680, y);
            y += 20;

            e.Graphics.DrawString("SỐ TIỀN:", boldFont, Brushes.Black, left, y);
            e.Graphics.DrawString(lblAmountValue.Text, boldFont, Brushes.Black, left + 280, y);
            y += lineHeight + 30;

            if (picQRCode.Visible && picQRCode.Image != null)
            {
                e.Graphics.DrawString("Mã QR chuyển khoản:", normalFont, Brushes.Black, left, y);
                y += lineHeight;

                e.Graphics.DrawImage(picQRCode.Image, left, y, 180, 180);
                y += 200;
            }

            e.Graphics.DrawString("Nhân viên xác nhận", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Khách hàng", normalFont, Brushes.Black, left + 460, y);
            y += 90;

            e.Graphics.DrawString("Cảm ơn quý khách đã sử dụng dịch vụ!", boldFont, Brushes.Black, left + 150, y);
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoiIn = MessageBox.Show(
                    "Thanh toán thành công.\nBạn có muốn in hóa đơn không?",
                    "In hóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (hoiIn == DialogResult.Yes)
                {
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.Width = 900;
                    printPreviewDialog.Height = 700;
                    printPreviewDialog.ShowDialog();
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác nhận thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handle cancel button click
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
