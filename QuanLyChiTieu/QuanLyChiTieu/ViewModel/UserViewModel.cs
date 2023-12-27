using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class UserViewModel : ViewModelBase
    {
        private NguoiDungDTO user;
        public NguoiDungDTO getUser
        {
            get { return user; }
        }
        private string _oldPassword;
        private string _newPassword;
        private string _confirmPass;
        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                OnPropertyChanged("OldPassword");
            }
        }
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }
        public string ConfirmPass
        {
            get { return _confirmPass; }
            set
            {
                _confirmPass = value;
                OnPropertyChanged("ConfirmPass");
            }
        }
        public ICommand LogOut { get; }
        public ICommand ChangePasswordCommand { get; }
        public UserViewModel()
        {
            user = new NguoiDungDTO();
            user = MainViewModel.currentUser;

            LogOut = new ViewModelCommand(ExecuteLogOut);
            ChangePasswordCommand = new ViewModelCommand(ExecuteChangePasswordCommand);
        }

        private void ExecuteLogOut(object obj)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            var mainWindow = obj as MainWindow;
            mainWindow.Close();
        }
        private void ExecuteChangePasswordCommand(object obj)
        {
            if(OldPassword != MainViewModel.currentUser.MatKhau)
            {
                MessageBox.Show("Nhập sai mật khẩu cũ!");
                OldPassword = "";
                NewPassword = "";
                ConfirmPass = "";
                return;
            }    
            if(OldPassword == NewPassword)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                NewPassword = "";
                ConfirmPass = "";
                return;
            }    
            if(NewPassword != ConfirmPass) 
            {
                MessageBox.Show("Xác nhận mật khẩu mới không trùng khớp!");
                ConfirmPass = "";
                return;
            }
            //Đổi mật khẩu thành công => gọi hàm đăng xuất 
            if (NguoiDungBUS.DoiMatKhau(NewPassword))
                ExecuteLogOut(obj);
        }
    }
}
