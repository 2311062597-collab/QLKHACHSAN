using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class DangNhapBLL
    {
        private DangNhapDAL dal = new DangNhapDAL();

        public DataTable KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return dal.KiemTraDangNhap(tenDangNhap, matKhau);
        }
    }
}