﻿using FontAwesome.Sharp;
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
                CustomMessageBoxViewModel dialogPassCheck = new CustomMessageBoxViewModel("Lỗi mật khẩu", "Mật khẩu nhập lại chưa đúng");
                CustomMessageBox messagePassCheck = new CustomMessageBox { DataContext = dialogPassCheck };
                messagePassCheck.ShowDialog();

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
                            CustomMessageBoxViewModel dialogSuccess = new CustomMessageBoxViewModel("Thành công", "Đăng ký tài khoản thành công, hãy đăng nhập lại để hoàn thành đăng ký");
                            CustomMessageBox messageSuccess = new CustomMessageBox { DataContext = dialogSuccess };
                            messageSuccess.ShowDialog();

                            LoginView loginView = new LoginView();
                            loginView.Show();

                            if (obj is Window window)
                            {
                                window.Close();
                            }
                        }
                        else if (result == 2)
                        {
                            CustomMessageBoxViewModel dialogUsername = new CustomMessageBoxViewModel("Lỗi tên đăng nhập", "Tên đăng nhập đã tồn tại, vui lòng thử lại");
                            CustomMessageBox messageUsername = new CustomMessageBox { DataContext = dialogUsername };
                            messageUsername.ShowDialog();

                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                        else if (result == 3)
                        {
                            CustomMessageBoxViewModel dialogPhone = new CustomMessageBoxViewModel("Lỗi số điện thoại", "Số điện thoại đã tồn tại, vui lòng thử lại");
                            CustomMessageBox messagePhone = new CustomMessageBox { DataContext = dialogPhone };
                            messagePhone.ShowDialog();
                            
                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                        else
                        {
                            CustomMessageBoxViewModel dialogData = new CustomMessageBoxViewModel("Lỗi database", "Có lỗi xảy ra trong quá trình đăng ký, vui lòng thử lại sau");
                            CustomMessageBox messageData = new CustomMessageBox { DataContext = dialogData };
                            messageData.ShowDialog();
                            
                            UserName = "";
                            PhoneNumber = "";
                            NewPassword = "";
                            ConfirmPass = "";
                        }
                    }
                }
                return;
            }
            CustomMessageBoxViewModel dialogMissing = new CustomMessageBoxViewModel("Thiếu thông tin", "Vui lòng điền đầy đủ thông tin trước khi đăng ký");
            CustomMessageBox messageMissing = new CustomMessageBox { DataContext = dialogMissing };
            messageMissing.ShowDialog();
        }
    }
}
