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
    public class EditDialogViewModel : ViewModelBase
    {
        public DataTable LoaiGiaoDichData { get; set; }
        public ICommand CloseCommand { get; }
        public EditDialogViewModel()
        {
            LoadLoaiGiaoDichData();

            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
        }
        public void LoadLoaiGiaoDichData()
        {
            LoaiGiaoDichData = LoaiGiaoDichBUS.LietKeLoaiGiaoDich();
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
