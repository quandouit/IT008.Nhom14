using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.BUS
{
    public class LoginBUS
    {
        public static NguoiDungDTO Try_Login(NguoiDungDTO user)
        {
            if (user.TaiKhoan is null) { user.TaiKhoan = ""; }
            if (user.MatKhau is null) { user.MatKhau = ""; }

            return LoginDAO.Try_Login(user);
        }
    }
}
