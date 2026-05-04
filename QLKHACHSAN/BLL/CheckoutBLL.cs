using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class CheckoutBLL
    {
        private CheckoutDAL dal = new CheckoutDAL();

        public DataTable GetThongTinCheckout(int maDatPhong)
        {
            if (maDatPhong <= 0)
                return new DataTable();

            return dal.GetThongTinCheckout(maDatPhong);
        }

        public DataTable GetDanhSachPhuongThuc()
        {
            return dal.GetDanhSachPhuongThuc();
        }

        public bool ThanhToanVaCheckout(int maDatPhong, int maPhuongThuc, decimal soTien, DateTime ngayTra, string ghiChu)
        {
            if (maDatPhong <= 0)
            {
                MessageBox.Show("Mã đặt phòng không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (maPhuongThuc <= 0)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (soTien <= 0)
            {
                MessageBox.Show("Số tiền thanh toán không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return dal.ThanhToanVaCheckout(maDatPhong, maPhuongThuc, soTien, ngayTra, ghiChu);
        }

        public decimal LayTongTien(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
                return 0;

            if (!dt.Columns.Contains("ThanhTien"))
                return 0;

            return Convert.ToDecimal(dt.Rows[0]["ThanhTien"]);
        }

        public string FormatCurrency(decimal value)
        {
            return value.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }
    }
}