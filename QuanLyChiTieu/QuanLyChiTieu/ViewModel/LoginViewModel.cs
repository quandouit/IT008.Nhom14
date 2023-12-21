using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace QuanLyChiTieu.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public bool IsLogin { get; set;}
        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(_username); }
            
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value; OnPropertyChanged(_password);
            }
        }

        public LoginViewModel()
        {
            IsLogin = false;
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { Password = p.Password; });
            LoginCommand = new RelayCommand<Window>((p) => { OnLogin(p); }, (p) => { return true; });
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
        }


        //Login command
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        private void OnLogin(Window p)
        {
            if (Username == "admin" &&  Password == "123")
                IsLogin = true;

        }
        
        //Closing command
        public ICommand CloseCommand { get; }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.Shutdown();
        }
    }
}
