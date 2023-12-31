using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
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
            return LoginDAO.Try_Login(user);
        }
    }
}
