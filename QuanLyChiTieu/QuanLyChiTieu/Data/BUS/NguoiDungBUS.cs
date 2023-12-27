using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.BUS
{
    public class NguoiDungBUS
    {
        public static int ThemNguoiDung(NguoiDungDTO user)
        {
            return NguoiDungDAO.ThemNguoiDung(user);
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
        public static bool DoiSotien(NguoiDungDTO input, decimal money)
        {
            if (NguoiDungDAO.DoiSotien(money, input.ID) == 0)
            {
                MessageBox.Show("Khởi tạo tài khoản thành công");
                return true;
            }
            else
                MessageBox.Show("Khởi tạo tài khoản thất bại!");
            return false;
        }
        public static NguoiDungDTO ThongTinNguoiDung(NguoiDungDTO user)
        {
            return NguoiDungDAO.ThongTinNguoiDung(user);
        }
    }
}
