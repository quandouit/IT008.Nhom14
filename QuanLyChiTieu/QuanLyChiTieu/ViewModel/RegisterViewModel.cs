using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using System.Diagnostics.Eventing.Reader;
using QuanLyChiTieu.View;

namespace QuanLyChiTieu.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private NguoiDungDTO user;
        private string _userName;
        private string _phoneNumber;
        private string _newPassword;
        private string _confirmPass;
        public string PasswordConfirmationError { get; private set; }
        private void UpdatePasswordConfirmationError()
        {
            if (_confirmPass != null && _confirmPass.Length > 0)
            {
                PasswordConfirmationError = _newPassword == _confirmPass ? "" : "Mật khẩu không khớp!";
            }
            else
            {
                PasswordConfirmationError = "";
            }
            OnPropertyChanged("PasswordConfirmationError");
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged("NewPassword");
                UpdatePasswordConfirmationError();
            }
        }
        public string ConfirmPass
        {
            get { return _confirmPass; }
            set
            {
                _confirmPass = value;
                OnPropertyChanged("ConfirmPass");
                UpdatePasswordConfirmationError();
            }
        }
        public ICommand CloseCommand { get; }
        public ICommand BackToLogInCommmand { get; }
        public ICommand TrySignUpCommmand { get; }
        public RegisterViewModel()
        {
            user = new NguoiDungDTO();
            PasswordConfirmationError = "";
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            BackToLogInCommmand = new ViewModelCommand(ExecuteBackToLogInCommmand);
            TrySignUpCommmand = new ViewModelCommand(ExecuteTrySignUpCommmand);

        }
        private void ExecuteCloseCommand(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
        private void ExecuteBackToLogInCommmand(object obj)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            if (obj is Window window)
            {
                window.Close();
            }
        }
        private void ExecuteTrySignUpCommmand(object obj)
        {
            if (_newPassword != _confirmPass)
            {
                MessageBox.Show("Mật khẩu nhập lại chưa đúng");
                return;
            }
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                if (!string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    if (!string.IsNullOrEmpty(NewPassword))
                    {
                        user.TaiKhoan = UserName;
                        user.Sdt = PhoneNumber;
                        user.MatKhau = NewPassword;
                        user.TongTien = -9999999999;
                        int result = NguoiDungBUS.ThemNguoiDung(user);

                        if (result == 0)
                        {
                            MessageBox.Show("Đăng ký tài khoản thành công, hãy đăng nhập lại để hoàn thành");

                            LoginView loginView = new LoginView();
                            loginView.Show();

                            if (obj is Window window)
                            {
                                window.Close();
                            }
                        }
                        else if (result == 2)
                        {
                            MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng thử lại");
                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                        else if (result == 3)
                        {
                            MessageBox.Show("Số điện thoại đã tồn tại, vui lòng thử lại");
                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau");
                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                    }
                }
                return;
            }
            MessageBox.Show("Vui lòng điền đầy đủ thông tin trước khi đăng ký");
        }
    }
}
