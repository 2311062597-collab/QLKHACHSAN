using System.Data;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public DataTable Tim(string keyword)
        {
            return dal.Tim(keyword);
        }

        public bool Sua(int maKH, string ten, string sdt, string cccd)
        {
            return dal.Sua(maKH, ten, sdt, cccd);
        }
        public bool Them(string ten, string sdt, string cccd)
        {
            return dal.Them(ten, sdt, cccd);
        }
    }
}