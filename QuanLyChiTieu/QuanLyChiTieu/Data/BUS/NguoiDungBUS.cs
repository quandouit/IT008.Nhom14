using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
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
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thành công", "Đổi mật khẩu thành công, vui lòng đăng nhập lại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return true;
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Đổi mật khẩu thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            return false;
        }
        public static bool DoiSotien(NguoiDungDTO input, decimal money)
        {
            if (NguoiDungDAO.DoiSotien(money, input.ID) == 0)
            {
                return true;
            }
            return false;
        }
        public static decimal LaySoDu(int ID)
        {
            decimal rt = NguoiDungDAO.LaySoDu(ID);
            if (rt == -1)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Lấy thông tin số dư người dùng thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            return rt;
        }
        public static decimal LayTongChi(int ID, int month, int year)
        {
            decimal rt = NguoiDungDAO.LayTongChi(ID, month, year);
            if (rt == -1)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Lấy thông tin tổng chi người dùng thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            return rt;
        }
        public static decimal LayTongThu(int ID, int month, int year)
        {
            decimal rt = NguoiDungDAO.LayTongThu(ID, month, year);
            if (rt == -1)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Lấy thông tin tổng thu người dùng thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            return rt;
        }
    }
}
