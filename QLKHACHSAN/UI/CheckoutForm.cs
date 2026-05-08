using System;
using System.Data;
using System.Windows.Forms;
using QLKHACHSAN.BLL;

namespace QLKHACHSAN.UI
{
    public partial class CheckoutForm : Form
    {
        private int maDatPhong;
        private CheckoutBLL checkoutBLL = new CheckoutBLL();
        private decimal tongTienTruocGiamGia = 0;

        public CheckoutForm(int bookingId)
        {
            InitializeComponent();
            maDatPhong = bookingId;
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

                txtTienPhong.Text = tienPhong.ToString("N0");
                txtTienDichVu.Text = tienDichVu.ToString("N0");

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

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
