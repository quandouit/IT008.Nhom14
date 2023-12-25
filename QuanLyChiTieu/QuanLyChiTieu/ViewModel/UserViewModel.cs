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
        public ICommand LogOut { get; }
        public UserViewModel()
        {
            user = new NguoiDungDTO();
            user = MainViewModel.currentUser;

            LogOut = new ViewModelCommand(ExecuteLogOut);
        }

        private void ExecuteLogOut(object obj)
        {
            LoginView loginView = new LoginView();
            loginView.Show();

            var mainWindow = obj as MainWindow;
            mainWindow.Close();
        }
    }
}
