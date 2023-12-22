using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using QuanLyChiTieu.Data.BUS;
using System.Data;
using QuanLyChiTieu.Model;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class DetailDialogViewModel : ViewModelBase
    {
        public GiaoDichModel GiaoDich { get; set; }
        public ICommand CloseCommand { get; }
        public DetailDialogViewModel(GiaoDichModel input)
        {
            GiaoDich = input;

            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
        }
        public DetailDialogViewModel() { }
        private void ExecuteCloseCommand(object obj)
        {
            if (obj is Window window)
            {
                window.Close();
            }
        }
    }
}
