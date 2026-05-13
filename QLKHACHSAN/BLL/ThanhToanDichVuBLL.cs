using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    /// <summary>
    /// Business Logic Layer for Service Payment (ThanhToanDichVu)
    /// Handles validation and business rules for service purchase payments
    /// </summary>
    public class ThanhToanDichVuBLL
    {
        private ThanhToanDichVuDAL dal = new ThanhToanDichVuDAL();
        private MuaDichVuDAL muaDichVuDAL = new MuaDichVuDAL();

        /// <summary>
        /// Validate payment information
        /// </summary>
        public bool ValidatePaymentInfo(string maKhachHang, string maDichVu, int soLuong, 
                                        decimal thanhTien, string phuongThuc)
        {
            // Validate customer ID
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate service ID
            if (string.IsNullOrWhiteSpace(maDichVu))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn dịch vụ!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate quantity
            if (soLuong <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate amount
            if (thanhTien < 0)
            {
                System.Windows.Forms.MessageBox.Show("Thành tiền không được âm!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            if (thanhTien == 0)
            {
                System.Windows.Forms.MessageBox.Show("Thành tiền phải lớn hơn 0!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate payment method
            if (string.IsNullOrWhiteSpace(phuongThuc))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Process service payment
        /// </summary>
        public bool ProcessPayment(string maKhachHang, string maNhanVien, string maDichVu,
                                   int soLuong, decimal thanhTien, string phuongThuc, DateTime ngayThanhToan)
        {
            try
            {
                // Validate payment information
                if (!ValidatePaymentInfo(maKhachHang, maDichVu, soLuong, thanhTien, phuongThuc))
                    return false;

                // Save payment to database
                bool result = dal.SavePayment(maKhachHang, maNhanVien, maDichVu, 
                                              soLuong, thanhTien, phuongThuc, ngayThanhToan);

                if (result)
                {
                    System.Windows.Forms.MessageBox.Show("Thanh toán dịch vụ thành công!", "Thành công",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Lỗi khi lưu thanh toán!", "Lỗi",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                return result;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi xử lý thanh toán: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Get service details
        /// </summary>
        public DataTable GetServiceDetails(string maDichVu)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDichVu))
                    return new DataTable();

                return dal.GetServiceDetails(maDichVu);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get customer details
        /// </summary>
        public DataTable GetCustomerDetails(string maKhachHang)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maKhachHang))
                    return new DataTable();

                return dal.GetCustomerDetails(maKhachHang);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin khách hàng: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Format currency value
        /// </summary>
        public string FormatCurrency(decimal value)
        {
            return value.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("vi-VN"));
        }

        /// <summary>
        /// Get payment receipt data
        /// </summary>
        public DataTable GetPaymentReceipt(string maDatDichVu)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(maDatDichVu))
                    return new DataTable();

                return dal.GetPaymentReceipt(maDatDichVu);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy hóa đơn: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}
