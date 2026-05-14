using System;
using System.Data;
using System.Windows.Forms;
using QLKHACHSAN.BLL;
using System.Drawing;
using System.Drawing.Printing;
namespace QLKHACHSAN.UI
{
    public partial class CheckoutForm : Form
    {
        private int maDatPhong;
        private CheckoutBLL checkoutBLL = new CheckoutBLL();
        private decimal tongTienTruocGiamGia = 0;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        public CheckoutForm(int bookingId)
        {
            InitializeComponent();
            maDatPhong = bookingId;

            printDocument.PrintPage += PrintDocument_PrintPage;
            btnInHoaDon.Click += btnInHoaDon_Click;
        }

        private void CheckoutForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPaymentMethods();
                LoadCheckoutInfo();
                CalculateTotalAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCheckoutInfo()
        {
            DataTable dtCheckout = checkoutBLL.GetThongTinCheckout(maDatPhong);

            if (dtCheckout != null && dtCheckout.Rows.Count > 0)
            {
                DataRow row = dtCheckout.Rows[0];

                // Map actual database column names to form fields
                txtTenKhachHang.Text = row["HoTen"]?.ToString() ?? "";
                txtMaPhong.Text = row["SoPhong"]?.ToString() ?? "";

                if (row["NgayNhan"] != DBNull.Value)
                    dateNgayNhan.Value = Convert.ToDateTime(row["NgayNhan"]);

                if (row["NgayTra"] != DBNull.Value)
                    dateNgayTra.Value = Convert.ToDateTime(row["NgayTra"]);

                // Get room charges from ThanhTien (room price × number of days)
                decimal tienPhong = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : 0;

                // Service charges - if there's a separate column, use it; otherwise set to 0
                decimal tienDichVu = 0;
                if (row.Table.Columns.Contains("TienDichVu") && row["TienDichVu"] != DBNull.Value)
                    tienDichVu = Convert.ToDecimal(row["TienDichVu"]);



                tongTienTruocGiamGia = tienPhong + tienDichVu;
            }
        }

        private void LoadPaymentMethods()
        {
            DataTable dtPhuongThuc = checkoutBLL.GetDanhSachPhuongThuc();

            if (dtPhuongThuc != null && dtPhuongThuc.Rows.Count > 0)
            {
                cbPhuongThuc.DataSource = dtPhuongThuc;
                cbPhuongThuc.DisplayMember = "TenPhuongThuc";
                cbPhuongThuc.ValueMember = "MaPhuongThuc";
                cbPhuongThuc.SelectedIndexChanged += CbPhuongThuc_SelectedIndexChanged;
            }
        }

        private void CbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler for payment method changes - currently just placeholder
            // Transfer code will only be shown when payment button is clicked
        }

        private void CalculateTotalAmount()
        {
            decimal giamGia = 0;

            if (decimal.TryParse(txtGiamGia.Text, out decimal giam))
            {
                giamGia = giam;
            }

            decimal tongCong = tongTienTruocGiamGia - giamGia;
            if (tongCong < 0) tongCong = 0;

            txtTongCong.Text = tongCong.ToString("N0");
            numSoTienThanhToan.Maximum = tongCong * 2;
        }

        private void CalculateBalance()
        {
            decimal tongCong = 0;

            // Parse total amount from display text (format: "10,000,000")
            if (!decimal.TryParse(txtTongCong.Text.Replace(",", ""), out tongCong))
            {
                txtSoTienThua.Text = "0";
                return;
            }

            decimal soTienTT = (decimal)numSoTienThanhToan.Value;
            decimal thua = soTienTT - tongCong;

            // Display refund amount (thua = refund)
            if (thua >= 0)
                txtSoTienThua.Text = thua.ToString("N0");
            else
                txtSoTienThua.Text = "0";
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
            CalculateBalance();
        }

        private void numSoTienThanhToan_ValueChanged(object sender, EventArgs e)
        {
            CalculateBalance();
        }

        private string GenerateTransferCode()
        {
            return "TT PHONG " + maDatPhong;
        }

        private void btnThanhToanCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPhuongThuc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal soTienTT = (decimal)numSoTienThanhToan.Value;

                if (soTienTT <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số tiền thanh toán!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maPhuongThuc = Convert.ToInt32(cbPhuongThuc.SelectedValue);
                DateTime ngayTra = dateNgayTra.Value;
                string ghiChu = txtGhiChu.Text.Trim();

                // Nếu chọn chuyển khoản thì hiện popup xác nhận trước khi lưu thanh toán
                if (IsTransferPaymentMethod())
                {
                    string maChuyenKhoan = GenerateTransferCode();

                    ChuyenKhoanConfirmForm frm = new ChuyenKhoanConfirmForm(soTienTT, maChuyenKhoan);

                    DialogResult confirmResult = frm.ShowDialog(this);

                    if (confirmResult != DialogResult.OK)
                    {
                        MessageBox.Show(
                            "Bạn đã hủy xác nhận chuyển khoản. Thanh toán chưa được lưu.",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }

                    ghiChu = (string.IsNullOrWhiteSpace(ghiChu) ? "" : ghiChu + "\n") +
                             "Mã CK: " + maChuyenKhoan +
                             "\nSTK: 2143312836 - BIDV - NGUYEN MAU HAI";
                }

                bool result = checkoutBLL.ThanhToanVaCheckout(maDatPhong, maPhuongThuc, soTienTT, ngayTra, ghiChu);

                if (result)
                {
                    MessageBox.Show("Thanh toán và trả phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsTransferPaymentMethod()
        {
            if (cbPhuongThuc.SelectedItem == null)
                return false;

            DataRowView drv = cbPhuongThuc.SelectedItem as DataRowView;
            if (drv == null)
                return false;

            string tenPhuongThuc = drv["TenPhuongThuc"]?.ToString() ?? "";
            return tenPhuongThuc.Contains("Chuyển khoản") || tenPhuongThuc.Contains("Transfer") || tenPhuongThuc.Contains("Bank");
        }
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog.Document = printDocument;
                printPreviewDialog.Width = 900;
                printPreviewDialog.Height = 700;
                printPreviewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi in hóa đơn: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

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

            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN PHÒNG", headerFont, Brushes.Black, left + 170, y);
            y += 40;

            e.Graphics.DrawString("Ngày in: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Tên khách hàng: " + txtTenKhachHang.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Phòng: " + txtMaPhong.Text, normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Ngày nhận: " + dateNgayNhan.Value.ToString("dd/MM/yyyy"), normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Ngày trả: " + dateNgayTra.Value.ToString("dd/MM/yyyy"), normalFont, Brushes.Black, left, y);
            y += lineHeight + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 680, y);
            y += 15;

            e.Graphics.DrawString("CHI TIẾT THANH TOÁN", headerFont, Brushes.Black, left, y);
            y += lineHeight + 5;

            e.Graphics.DrawString("Tiền phòng:", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString(txtTienPhong.Text + " đ", normalFont, Brushes.Black, left + 280, y);
            y += lineHeight;

            e.Graphics.DrawString("Tiền dịch vụ:", normalFont, Brushes.Black, left, y);
            y += lineHeight;

            e.Graphics.DrawString("Giảm giá:", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString(txtGiamGia.Text + " đ", normalFont, Brushes.Black, left + 280, y);
            y += lineHeight;

            e.Graphics.DrawString("Phương thức:", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString(cbPhuongThuc.Text, normalFont, Brushes.Black, left + 280, y);
            y += lineHeight + 10;

            e.Graphics.DrawLine(Pens.Black, left, y, left + 680, y);
            y += 20;

            e.Graphics.DrawString("TỔNG CỘNG:", boldFont, Brushes.Black, left, y);
            e.Graphics.DrawString(txtTongCong.Text + " đ", boldFont, Brushes.Black, left + 280, y);
            y += lineHeight;

            e.Graphics.DrawString("Số tiền khách trả:", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString(numSoTienThanhToan.Value.ToString("N0") + " đ", normalFont, Brushes.Black, left + 280, y);
            y += lineHeight;

            e.Graphics.DrawString("Tiền thừa:", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString(txtSoTienThua.Text + " đ", normalFont, Brushes.Black, left + 280, y);
            y += lineHeight + 20;

            if (!string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                e.Graphics.DrawString("Ghi chú:", normalFont, Brushes.Black, left, y);
                y += lineHeight;
                e.Graphics.DrawString(txtGhiChu.Text, normalFont, Brushes.Black, left, y);
                y += lineHeight + 20;
            }

            e.Graphics.DrawString("Nhân viên xác nhận", normalFont, Brushes.Black, left, y);
            e.Graphics.DrawString("Khách hàng", normalFont, Brushes.Black, left + 460, y);
            y += 90;

            e.Graphics.DrawString("Cảm ơn quý khách đã sử dụng dịch vụ!", boldFont, Brushes.Black, left + 150, y);
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
