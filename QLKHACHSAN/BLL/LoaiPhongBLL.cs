using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class LoaiPhongBLL
    {
        private LoaiPhongDAL dal = new LoaiPhongDAL();

        public DataTable GetDanhSachLoaiPhong()
        {
            return dal.GetDanhSachLoaiPhong();
        }

        public DataTable TimLoaiPhong(string tuKhoa)
        {
            return dal.TimLoaiPhong(tuKhoa);
        }

        public bool KiemTraLoaiPhongTonTai(string tenLoaiPhong)
        {
            return dal.KiemTraLoaiPhongTonTai(tenLoaiPhong);
        }

        public bool ThemLoaiPhong(string tenLoaiPhong, decimal gia, string moTa)
        {
            return dal.ThemLoaiPhong(tenLoaiPhong, gia, moTa);
        }

        public bool SuaLoaiPhong(int maLoaiPhong, string tenLoaiPhong, decimal gia, string moTa)
        {
            return dal.SuaLoaiPhong(maLoaiPhong, tenLoaiPhong, gia, moTa);
        }

        public bool LoaiPhongDangDuocSuDung(int maLoaiPhong)
        {
            return dal.LoaiPhongDangDuocSuDung(maLoaiPhong);
        }

        public bool XoaLoaiPhong(int maLoaiPhong)
        {
            return dal.XoaLoaiPhong(maLoaiPhong);
        }
    }
}