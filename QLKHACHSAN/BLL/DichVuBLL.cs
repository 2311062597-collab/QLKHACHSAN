using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class DichVuBLL
    {
        private DichVuDAL dal = new DichVuDAL();

        public DataTable GetDanhSachDichVu()
        {
            return dal.GetDanhSachDichVu();
        }

        public DataTable TimDichVu(string tuKhoa)
        {
            return dal.TimDichVu(tuKhoa);
        }

        public DataTable GetLoaiDichVu()
        {
            return dal.GetLoaiDichVu();
        }

        public bool KiemTraLoaiDichVuTonTai(string tenLoai)
        {
            return dal.KiemTraLoaiDichVuTonTai(tenLoai);
        }

        public int ThemLoaiDichVu(string tenLoai, string donViTinh)
        {
            return dal.ThemLoaiDichVu(tenLoai, donViTinh);
        }

        public bool ThemDichVu(string tenDichVu, int maLoaiDichVu, decimal donGia, string moTa, string trangThai)
        {
            return dal.ThemDichVu(tenDichVu, maLoaiDichVu, donGia, moTa, trangThai);
        }

        public bool SuaLoaiDichVu(int maLoaiDichVu, string tenLoai, string donViTinh)
        {
            return dal.SuaLoaiDichVu(maLoaiDichVu, tenLoai, donViTinh);
        }

        public bool SuaDichVu(int maDichVu, string tenDichVu, int maLoaiDichVu, decimal donGia, string moTa, string trangThai)
        {
            return dal.SuaDichVu(maDichVu, tenDichVu, maLoaiDichVu, donGia, moTa, trangThai);
        }

        public bool XoaDichVu(int maDichVu)
        {
            return dal.XoaDichVu(maDichVu);
        }
    }
}