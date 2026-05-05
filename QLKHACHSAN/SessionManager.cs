using System;

namespace QLKHACHSAN
{
    /// <summary>
    /// Quản lý thông tin session người dùng hiện tại
    /// </summary>
    public static class SessionManager
    {
        public static int MaTaiKhoan { get; set; }
        public static string TenDangNhap { get; set; }
        public static string TenChucVu { get; set; }
        public static string TrangThai { get; set; }

        public static void Clear()
        {
            MaTaiKhoan = 0;
            TenDangNhap = null;
            TenChucVu = null;
            TrangThai = null;
        }

        public static bool IsLoggedIn()
        {
            return MaTaiKhoan > 0;
        }
    }
}
