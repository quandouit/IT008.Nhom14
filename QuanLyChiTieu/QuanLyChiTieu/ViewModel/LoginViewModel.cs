using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace QuanLyChiTieu.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public LoginViewModel()
        {
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
        }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
