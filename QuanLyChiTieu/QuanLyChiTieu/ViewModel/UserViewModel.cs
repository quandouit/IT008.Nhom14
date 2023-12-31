﻿using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
            YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Đăng xuất", "Bạn có muốn đăng xuất không?");
            dialogViewModel.DialogClosed += result =>
            {
                if (result == DialogResult.OK)
                {
                    LoginView loginView = new LoginView();
                    loginView.Show();

                    var mainWindow = obj as MainWindow;
                    mainWindow.Close();
                }
            };
            YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
            messageBox.ShowDialog();
        }
        private void ExecuteChangePasswordCommand(object obj)
        {
            if(OldPassword != MainViewModel.currentUser.MatKhau)
            {
                CustomMessageBoxViewModel dialogOldPass = new CustomMessageBoxViewModel("Sai mật khẩu", "Nhập sai mật khẩu cũ!");
                CustomMessageBox messageOldPass = new CustomMessageBox { DataContext = dialogOldPass };
                messageOldPass.ShowDialog();
                
                OldPassword = "";
                NewPassword = "";
                ConfirmPass = "";
                return;
            }    
            if(OldPassword == NewPassword)
            {
                CustomMessageBoxViewModel dialogNewPass = new CustomMessageBoxViewModel("Trùng mật khẩu cũ", "Vui lòng nhập mật khẩu mới!");
                CustomMessageBox messageNewPass = new CustomMessageBox { DataContext = dialogNewPass };
                messageNewPass.ShowDialog();

                NewPassword = "";
                ConfirmPass = "";
                return;
            }    
            if(NewPassword != ConfirmPass) 
            {
                CustomMessageBoxViewModel dialogNotMatch = new CustomMessageBoxViewModel("Nhập lại sai", "Xác nhận mật khẩu mới không trùng khớp!");
                CustomMessageBox messageNotMatch = new CustomMessageBox { DataContext = dialogNotMatch };
                messageNotMatch.ShowDialog();

                ConfirmPass = "";
                return;
            }
            if (NguoiDungBUS.DoiMatKhau(NewPassword))
            {
                LoginView loginView = new LoginView();
                loginView.Show();

                var mainWindow = obj as MainWindow;
                mainWindow.Close();
            }
        }
    }
}
