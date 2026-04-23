using System;
using System.Data;
using System.Data.SqlClient;

namespace QLKHACHSAN.DAL
{
    /// <summary>
    /// Data Access Layer for MuaDichVu (Service Purchase)
    /// Handles all database operations for service purchases
    /// </summary>
    public class MuaDichVuDAL
    {
        private DBConnection db = new DBConnection();

        /// <summary>
        /// Get all service purchases from database
        /// </summary>
        public DataTable GetAll()
        {
            try
            {
                string sql = "SELECT MaDatDichVu, MaKhachHang, MaNhanVien, MaDichVu, " +
                            "SoLuong, ThanhTien, MaPhuongThuc, NgayThanhToan " +
                            "FROM DatDichVu ORDER BY NgayThanhToan DESC";
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy danh sách dịch vụ: " + ex.Message, "Lỗi", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Get service purchase by ID
        /// </summary>
        public DataTable GetById(string maDatDichVu)
        {
            try
            {
                string sql = "SELECT MaDatDichVu, MaKhachHang, MaNhanVien, MaDichVu, " +
                            "SoLuong, ThanhTien, MaPhuongThuc, NgayThanhToan " +
                            "FROM DatDichVu WHERE MaDatDichVu = @ma";

                SqlParameter[] parameters = {
                    new SqlParameter("@ma", maDatDichVu)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi lấy thông tin dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }

        /// <summary>
        /// Insert new service purchase
        /// </summary>
        public bool Insert(string ma, string makh, string manv, string madv,
                           int soluong, decimal thanhtien, string mapt, DateTime ngay)
        {
            try
            {
                string sql = @"INSERT INTO DatDichVu 
                            (MaDatDichVu, MaKhachHang, MaNhanVien, MaDichVu, 
                             SoLuong, ThanhTien, MaPhuongThuc, NgayThanhToan)
                            VALUES (@ma, @makh, @manv, @madv, @soluong, @thanhtien, @mapt, @ngay)";

                SqlParameter[] parameters = {
                    new SqlParameter("@ma", ma ?? ""),
                    new SqlParameter("@makh", makh ?? ""),
                    new SqlParameter("@manv", manv ?? ""),
                    new SqlParameter("@madv", madv ?? ""),
                    new SqlParameter("@soluong", soluong),
                    new SqlParameter("@thanhtien", thanhtien),
                    new SqlParameter("@mapt", mapt ?? ""),
                    new SqlParameter("@ngay", ngay)
                };

                int result = db.ExecuteNonQuery(sql, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Update existing service purchase
        /// </summary>
        public bool Update(string ma, string makh, string manv, string madv,
                           int soluong, decimal thanhtien, string mapt, DateTime ngay)
        {
            try
            {
                string sql = @"UPDATE DatDichVu SET 
                            MaKhachHang = @makh,
                            MaNhanVien = @manv,
                            MaDichVu = @madv,
                            SoLuong = @soluong,
                            ThanhTien = @thanhtien,
                            MaPhuongThuc = @mapt,
                            NgayThanhToan = @ngay
                            WHERE MaDatDichVu = @ma";

                SqlParameter[] parameters = {
                    new SqlParameter("@ma", ma ?? ""),
                    new SqlParameter("@makh", makh ?? ""),
                    new SqlParameter("@manv", manv ?? ""),
                    new SqlParameter("@madv", madv ?? ""),
                    new SqlParameter("@soluong", soluong),
                    new SqlParameter("@thanhtien", thanhtien),
                    new SqlParameter("@mapt", mapt ?? ""),
                    new SqlParameter("@ngay", ngay)
                };

                int result = db.ExecuteNonQuery(sql, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Delete service purchase by ID
        /// </summary>
        public bool Delete(string maDatDichVu)
        {
            try
            {
                string sql = "DELETE FROM DatDichVu WHERE MaDatDichVu = @ma";

                SqlParameter[] parameter = {
                    new SqlParameter("@ma", maDatDichVu)
                };

                int result = db.ExecuteNonQuery(sql, parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Search service purchases by customer ID
        /// </summary>
        public DataTable SearchByCustomer(string maKhachHang)
        {
            try
            {
                string sql = "SELECT MaDatDichVu, MaKhachHang, MaNhanVien, MaDichVu, " +
                            "SoLuong, ThanhTien, MaPhuongThuc, NgayThanhToan " +
                            "FROM DatDichVu WHERE MaKhachHang = @ma ORDER BY NgayThanhToan DESC";

                SqlParameter[] parameters = {
                    new SqlParameter("@ma", maKhachHang)
                };

                return db.ExecuteQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return new DataTable();
            }
        }
    }
}
