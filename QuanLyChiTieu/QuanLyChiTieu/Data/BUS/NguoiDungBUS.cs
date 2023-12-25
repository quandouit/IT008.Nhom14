using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(x == 0) { MessageBox.Show("Tao tai khoan moi thanh cong!"); }
            else if (x == 1) { MessageBox.Show("Tao tai khoan moi that bai!"); }
            else if (x == 2) { MessageBox.Show("Tai khoan da ton tai!"); }
        }
    }
}
