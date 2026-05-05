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

namespace QLKHACHSAN.UI
{
    public partial class TaiKhoanForm : Form
    {
        private TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();
        private int maTaiKhoan;

        public TaiKhoanForm()
        {
            InitializeComponent();
        }

        // Constructor to accept MaTaiKhoan
        public TaiKhoanForm(int maTaiKhoan)
        {
            InitializeComponent();
            this.maTaiKhoan = maTaiKhoan;
        }

        private void TaiKhoanForm_Load(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[TaiKhoanForm] Load - MaTaiKhoan: {maTaiKhoan}");
                LoadThongTinTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải form: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"[TaiKhoanForm] Error: {ex}");
            }
        }

        private void LoadThongTinTaiKhoan()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] Starting - MaTaiKhoan: {maTaiKhoan}");

                DataTable dt = taiKhoanBLL.GetThongTinTaiKhoan(maTaiKhoan);
                System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] DataTable rows: {dt?.Rows.Count ?? 0}");

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] Columns: {string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName))}");

                    // Thông tin tài khoản đăng nhập
                    txtTenDangNhap.Text = row["TenDangNhap"].ToString();
                    txtChucVu.Text = row["TenChucVu"] != DBNull.Value ? row["TenChucVu"].ToString() : "N/A";
                    txtTrangThai.Text = row["TrangThai"].ToString();

                    // Thông tin hồ sơ cá nhân
                    txtHoTen.Text = row["HoTen"] != DBNull.Value ? row["HoTen"].ToString() : "N/A";
                    txtCCCD.Text = row["CCCD"] != DBNull.Value ? row["CCCD"].ToString() : "N/A";
                    txtSoDienThoai.Text = row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "N/A";
                    txtGioiTinh.Text = row["GioiTinh"] != DBNull.Value ? row["GioiTinh"].ToString() : "N/A";
                    txtDiaChi.Text = row["DiaChi"] != DBNull.Value ? row["DiaChi"].ToString() : "N/A";

                    System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] Successfully loaded account info");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] No data found for MaTaiKhoan: {maTaiKhoan}");
                    MessageBox.Show("Không tìm thấy thông tin tài khoản.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[LoadThongTinTaiKhoan] Exception: {ex}");
                MessageBox.Show("Lỗi khi tải thông tin tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
