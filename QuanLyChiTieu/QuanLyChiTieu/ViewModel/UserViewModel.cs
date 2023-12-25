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
        public ICommand LogOut { get; }
        public UserViewModel()
        {
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
