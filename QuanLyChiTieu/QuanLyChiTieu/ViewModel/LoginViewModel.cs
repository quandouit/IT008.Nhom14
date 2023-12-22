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

namespace QuanLyChiTieu.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public bool IsLogin;
        private string _user;
        private string _password;

        public string Username { get; set; }
        public string Password { get; set; }    

        public ICommand CloseCommand { get; }
        public ICommand EmailTextChangedCommand { get; }
        public ICommand EmailMouseDownCommand { get; }
        public ICommand PassWordTextChangedCommand { get; }
        public ICommand PassWordMouseDownCommand { get; }
        public ICommand SignInButtonCommand { get; }

        public LoginViewModel()
        {
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            EmailTextChangedCommand = new ViewModelCommand(ExecuteEmailTextChangedCommand);
            EmailMouseDownCommand = new ViewModelCommand(ExecuteEmailMouseDownCommand);
            PassWordMouseDownCommand = new ViewModelCommand(ExecutePassWordMouseDownCommand);
            PassWordTextChangedCommand = new ViewModelCommand(ExecutePassWordTextChangedCommand);
            SignInButtonCommand = new ViewModelCommand(ExecuteSignInButtonCommand);
        }

        private void ExecutePassWordTextChangedCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteEmailMouseDownCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecutePassWordMouseDownCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteSignInButtonCommand(object obj)
        {
            if(Username == "admin" && Password == "123")
            {
                MessageBox.Show("DAng nhap thanh cong");
            }
            else
            {
                MessageBox.Show("Ten dang nhap hoac mat khau sai");
            }
        }

        private void ExecuteEmailTextChangedCommand(object obj)
        {
            //throw new NotImplementedException();
        }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.Shutdown();
        }

    }
}
