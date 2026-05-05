using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKHACHSAN.DAL;

namespace QLKHACHSAN.BLL
{
    public class TaiKhoanBLL
    {
        private TaiKhoanDAL dal = new TaiKhoanDAL();

        public DataTable GetThongTinTaiKhoan(int maTaiKhoan)
        {
            return dal.GetThongTinTaiKhoan(maTaiKhoan);
        }
    }
}
