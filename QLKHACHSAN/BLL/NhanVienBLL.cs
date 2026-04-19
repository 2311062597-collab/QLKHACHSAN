using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public DataTable GetDanhSachNhanVien()
        {
            return dal.GetDanhSachNhanVien();
        }

        public DataTable TimNhanVien(string tuKhoa)
        {
            return dal.TimNhanVien(tuKhoa);
        }

        public DataTable GetChucVu()
        {
            return dal.GetChucVu();
        }

        public bool ThemNhanVien(
            string tenDangNhap,
            string matKhau,
            int maChucVu,
            string trangThai,
            string hoTen,
            string cccd,
            string sdt,
            string gioiTinh,
            string diaChi)
        {
            return dal.ThemNhanVien(tenDangNhap, matKhau, maChucVu, trangThai, hoTen, cccd, sdt, gioiTinh, diaChi);
        }

        public bool SuaNhanVien(
            int maNhanVien,
            int maTaiKhoan,
            string tenDangNhap,
            string matKhau,
            int maChucVu,
            string trangThai,
            string hoTen,
            string cccd,
            string sdt,
            string gioiTinh,
            string diaChi)
        {
            return dal.SuaNhanVien(maNhanVien, maTaiKhoan, tenDangNhap, matKhau, maChucVu, trangThai, hoTen, cccd, sdt, gioiTinh, diaChi);
        }
    }
}