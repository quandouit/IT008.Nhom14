using QuanLyChiTieu.Data.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public bool IsAllSelected { get; set; }
        public DataTable GiaoDichData { get; set; }
        public ICommand AddNewBillCommand { get; }
        public ICommand DeleteChoosenBillCommand { get; }
        public ICommand ShowInfoBillCommand { get; }
        public ICommand DeleteSingleBillCommand { get; }
        public ICommand UpdateIsAllSelectedCommand { get; set; }

        public ManageViewModel()
        {
            LoadGiaoDichData();

            AddNewBillCommand = new ViewModelCommand(ExecuteAddNewBillCommand);
            DeleteChoosenBillCommand = new ViewModelCommand(ExecuteDeleteChoosenBillCommand);
            ShowInfoBillCommand = new ViewModelCommand(ExecuteShowInfoBillCommand);
            DeleteSingleBillCommand = new ViewModelCommand(ExecuteDeleteSingleBillCommand);
            
            UpdateIsAllSelectedCommand = new ViewModelCommand(ExecuteUpdateIsAllSelectedCommand);
        }

        public void LoadGiaoDichData()
        {
            GiaoDichData = GiaoDichBUS.LietKeGiaoDich();
            DataColumn isCheckedColumn = new DataColumn("IsChecked", typeof(bool))
            {
                DefaultValue = false
            };
            GiaoDichData.Columns.Add(isCheckedColumn);
        }
        private void ExecuteAddNewBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien Them moi giao dich");
        }
        private void ExecuteDeleteChoosenBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien xoa cac giao dich da chon");
        }
        private void ExecuteShowInfoBillCommand(object obj)
        {
            MessageBox.Show("Hien thi thong tin chi tiet giao dich");
        }
        private void ExecuteDeleteSingleBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien xoa giao dich nay");
        }
        private void ExecuteUpdateIsAllSelectedCommand(object obj)
        {
            CheckBox checkBox = obj as CheckBox;
            if (checkBox.Name == "HeaderCheckBox")
            {
                foreach (DataRow row in GiaoDichData.Rows)
                {
                    row["IsChecked"] = IsAllSelected;
                }
                OnPropertyChanged(nameof(IsAllSelected));
            }
            else
            {
                IsAllSelected = GiaoDichData.Rows.Cast<DataRow>().All(row => (bool)row["IsChecked"]);
                OnPropertyChanged(nameof(IsAllSelected));
            }
        }
    }
}
