using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public DataTable GiaoDichData { get; set; }
        public ICommand AddNewBillCommand { get; }
        public ICommand DeleteChoosenBillCommand { get; }
        public ICommand ShowInfoBillCommand { get; }
        public ICommand DeleteSingleBillCommand { get; }
        public ManageViewModel()
        {
            LoadGiaoDichData();

            AddNewBillCommand = new ViewModelCommand(ExecuteAddNewBillCommand);
            DeleteChoosenBillCommand = new ViewModelCommand(ExecuteDeleteChoosenBillCommand);
            ShowInfoBillCommand = new ViewModelCommand(ExecuteShowInfoBillCommand);
            DeleteSingleBillCommand = new ViewModelCommand(ExecuteDeleteSingleBillCommand);
        }

        public void LoadGiaoDichData()
        {
            GiaoDichData = GiaoDichBUS.LietKeGiaoDich();
            OnPropertyChanged(nameof(GiaoDichData));
        }
        private void ExecuteAddNewBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien Them moi giao dich");
            /*
            GiaoDichDTO gd = new GiaoDichDTO();
            GiaoDichBUS.ThemGiaoDich(gd);
            LoadGiaoDichData();
            */
        }
        private void ExecuteDeleteChoosenBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien xoa cac giao dich da chon");
        }
        private void ExecuteShowInfoBillCommand(object obj)
        {
            if(obj is DataRowView selectedRow)
            {
                GiaoDichBUS.HienThiChiTietGiaoDich(selectedRow[0]);
            }
        }
        private void ExecuteDeleteSingleBillCommand(object obj)
        {
            if (obj is DataRowView selectedRow)
            {
                GiaoDichBUS.XoaGiaoDich(selectedRow[0]);
            }
            LoadGiaoDichData();
        }
    }
}
