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

namespace QuanLyChiTieu.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public ICommand CloseCommand { get; }
        public RegisterViewModel()
        {
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
        }
        private void ExecuteCloseCommand(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
}
