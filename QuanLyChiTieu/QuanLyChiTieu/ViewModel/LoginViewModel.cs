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
using QuanLyChiTieu.View;
using System.Windows.Forms;

namespace QuanLyChiTieu.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private NguoiDungDTO loginUser;
        public string Username
        {
            get { return loginUser.TaiKhoan; }
            set
            {
                loginUser.TaiKhoan = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return loginUser.MatKhau; }
            set
            {
                loginUser.MatKhau = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand CloseCommand { get; }
        public ICommand SignInButtonCommand { get; }
        public ICommand SignUpButtonCommand { get; }
        public LoginViewModel()
        {
            loginUser = new NguoiDungDTO();
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            SignInButtonCommand = new ViewModelCommand(ExecuteSignInButtonCommand);
            SignUpButtonCommand = new ViewModelCommand(ExecuteSignUpButtonCommand);
        }

        private void ExecuteSignUpButtonCommand(object obj)
        {
            RegisterView registerView = new RegisterView();
            registerView.Show(); 
            var loginWindow = obj as Window;
            loginWindow.Close();
        }
        private void ExecuteSignInButtonCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(loginUser.TaiKhoan) || string.IsNullOrWhiteSpace(loginUser.MatKhau))
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thiếu thông tin", "Vui lòng điền đầy đủ tên đăng nhập và mật khẩu");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
                return;
            }

            NguoiDungDTO currentUser = LoginBUS.Try_Login(loginUser);
            if (currentUser.ID != 0)
            {
                MainViewModel viewModel = new MainViewModel(currentUser);
                MainWindow mainWindow = new MainWindow { DataContext = viewModel };
                System.Windows.Application.Current.MainWindow = mainWindow;
                mainWindow.Show();

                var loginWindow = obj as Window;
                loginWindow.Close();
            }
            else
            {
                CustomMessageBoxViewModel messageViewModel = new CustomMessageBoxViewModel("Thông báo", "Tên đăng nhập hoặc mật khẩu sai!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = messageViewModel };
                messageBox.ShowDialog();

                Password = "";
            }
        }
        private void ExecuteCloseCommand(object obj)
        {
            if (obj is Window window)
            {
                YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Thoát ứng dụng", "Bạn có muốn thoát ứng dụng?");
                dialogViewModel.DialogClosed += result =>
                {
                    if (result == DialogResult.OK)
                    {
                        window.Close();
                    }
                };
                YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
    }
}
