using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class LoaiDichVuBLL
    {
        private LoaiDichVuDAL dal = new LoaiDichVuDAL();

        public DataTable GetDanhSachLoaiDichVu()
        {
            return dal.GetDanhSachLoaiDichVu();
        }

        public DataTable TimLoaiDichVu(string tuKhoa)
        {
            return dal.TimLoaiDichVu(tuKhoa);
        }

        public bool KiemTraLoaiDichVuTonTai(string tenLoai)
        {
            return dal.KiemTraLoaiDichVuTonTai(tenLoai);
        }

        public bool ThemLoaiDichVu(string tenLoai, string donViTinh)
        {
            return dal.ThemLoaiDichVu(tenLoai, donViTinh);
        }

        public bool SuaLoaiDichVu(int maLoaiDichVu, string tenLoai, string donViTinh)
        {
            return dal.SuaLoaiDichVu(maLoaiDichVu, tenLoai, donViTinh);
        }

        public bool LoaiDichVuConDichVu(int maLoaiDichVu)
        {
            return dal.LoaiDichVuConDichVu(maLoaiDichVu);
        }

        public bool LoaiDichVuDangDuocKhachSuDung(int maLoaiDichVu)
        {
            return dal.LoaiDichVuDangDuocKhachSuDung(maLoaiDichVu);
        }

        public bool XoaLoaiDichVu(int maLoaiDichVu)
        {
            return dal.XoaLoaiDichVu(maLoaiDichVu);
        }
    }
}