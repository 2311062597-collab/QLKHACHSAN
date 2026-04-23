using System;
using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    /// <summary>
    /// Business Logic Layer for MuaDichVu (Service Purchase)
    /// Handles validation and business rules for service purchases
    /// </summary>
    public class MuaDichVuBLL
    {
        private MuaDichVuDAL dal = new MuaDichVuDAL();

        /// <summary>
        /// Get all service purchases
        /// </summary>
        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        /// <summary>
        /// Get service purchase by ID
        /// </summary>
        public DataTable GetById(string maDatDichVu)
        {
            if (string.IsNullOrWhiteSpace(maDatDichVu))
                return new DataTable();

            return dal.GetById(maDatDichVu);
        }

        /// <summary>
        /// Add new service purchase with validation
        /// </summary>
        public bool Them(string makh, string manv, string madv,
                         int soluong, decimal thanhtien, string mapt, DateTime ngay)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(makh) || 
                string.IsNullOrWhiteSpace(manv) || string.IsNullOrWhiteSpace(madv))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate quantity
            if (soluong <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate amount
            if (thanhtien < 0)
            {
                System.Windows.Forms.MessageBox.Show("Thành tiền không được âm!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate date
            if (ngay > DateTime.Now)
            {
                System.Windows.Forms.MessageBox.Show("Ngày thanh toán không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return dal.Insert(makh, manv, madv, soluong, thanhtien, mapt, ngay);
        }

        /// <summary>
        /// Update service purchase with validation
        /// </summary>
        public bool Sua(string ma, string makh, string manv, string madv,
                        int soluong, decimal thanhtien, string mapt, DateTime ngay)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(makh) ||
                string.IsNullOrWhiteSpace(manv) || string.IsNullOrWhiteSpace(madv))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate quantity
            if (soluong <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Số lượng phải lớn hơn 0!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate amount
            if (thanhtien < 0)
            {
                System.Windows.Forms.MessageBox.Show("Thành tiền không được âm!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            // Validate date
            if (ngay > DateTime.Now)
            {
                System.Windows.Forms.MessageBox.Show("Ngày thanh toán không được lớn hơn ngày hôm nay!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            return dal.Update(ma, makh, manv, madv, soluong, thanhtien, mapt, ngay);
        }

        /// <summary>
        /// Delete service purchase by ID with confirmation
        /// </summary>
        public bool Xoa(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma))
            {
                System.Windows.Forms.MessageBox.Show("Vui lòng chọn dịch vụ để xóa!", "Cảnh báo",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return false;
            }

            var result = System.Windows.Forms.MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận",
                System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
                return dal.Delete(ma);

            return false;
        }

        /// <summary>
        /// Search service purchases by customer ID
        /// </summary>
        public DataTable SearchByCustomer(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
                return new DataTable();

            return dal.SearchByCustomer(maKhachHang);
        }
    }
}
