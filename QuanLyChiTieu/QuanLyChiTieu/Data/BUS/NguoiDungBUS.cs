using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.BUS
{
    public class NguoiDungBUS
    {
        public static void ThemNguoiDung(NguoiDungDTO user)
        {
            int x = NguoiDungDAO.ThemNguoiDung(user);
            if(x == 0) { MessageBox.Show("Tạo mới tài khoản thành công!"); }
            else if (x == 1) { MessageBox.Show("Tạo mới tài khoản thất bại!"); }
            else if (x == 2) { MessageBox.Show("Tên tài khoản đã tồn tại!"); }
        }
        public static bool DoiMatKhau(string pass)
        {
            if (NguoiDungDAO.DoiMatKhau(pass) == 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công, vui lòng đăng nhập lại!");
                return true;
            }
            else
                MessageBox.Show("Đổi mật khẩu thất bại!");
            return false;
        }
    }
}
