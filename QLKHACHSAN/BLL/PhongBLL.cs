using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class PhongBLL
    {
        private PhongDAL dal = new PhongDAL();

        public DataTable GetDanhSachPhong()
        {
            return dal.GetDanhSachPhong();
        }

        public DataTable TimPhong(string soPhong, string tang, string maLoaiPhong)
        {
            return dal.TimPhong(soPhong, tang, maLoaiPhong);
        }

        public DataTable GetLoaiPhong()
        {
            return dal.GetLoaiPhong();
        }

        public bool ThemPhong(string soPhong, int tang, int maLoaiPhong, string trangThai)
        {
            return dal.ThemPhong(soPhong, tang, maLoaiPhong, trangThai);
        }

        public bool SuaPhong(int maPhong, string soPhong, int tang, int maLoaiPhong, string trangThai)
        {
            return dal.SuaPhong(maPhong, soPhong, tang, maLoaiPhong, trangThai);
        }
    }
}