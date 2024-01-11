using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public bool IsAllSelected { get; set; }
        public BindingList<GiaoDichModel> GiaoDichTable
        {
            get { return MainViewModel.listGiaoDich; }
            set
            {
                MainViewModel.listGiaoDich = value;
                OnPropertyChanged(nameof(GiaoDichTable));
            }
        }
        public ICommand AddNewBillCommand { get; }
        public ICommand DeleteChoosenBillCommand { get; }
        public ICommand ShowInfoBillCommand { get; }
        public ICommand DeleteSingleBillCommand { get; }
        public ICommand UpdateIsAllSelectedCommand { get; set; }
        public ICommand SortRecentFirstCommand { get; }
        public ICommand SortRecentLastCommand { get; }

        public ManageViewModel()
        {
            AddNewBillCommand = new ViewModelCommand(ExecuteAddNewBillCommand);
            DeleteChoosenBillCommand = new ViewModelCommand(ExecuteDeleteChoosenBillCommand);
            ShowInfoBillCommand = new ViewModelCommand(ExecuteShowInfoBillCommand);
            DeleteSingleBillCommand = new ViewModelCommand(ExecuteDeleteSingleBillCommand);
            SortRecentFirstCommand = new ViewModelCommand(ExecuteSortRecentFirstCommand);
            SortRecentLastCommand = new ViewModelCommand(ExecuteSortRecentLastCommand);

            UpdateIsAllSelectedCommand = new ViewModelCommand(ExecuteUpdateIsAllSelectedCommand);
        }
        public void ReloadTable()
        {
            GiaoDichTable = new BindingList<GiaoDichModel>();
            GiaoDichTable = GiaoDichBUS.SapXepGanTruoc(GiaoDichBUS.LietKeGiaoDich());
        }
        private void ExecuteSortRecentFirstCommand(object obj)
        {
            GiaoDichTable = GiaoDichBUS.SapXepGanTruoc(GiaoDichTable);
        }
        private void ExecuteSortRecentLastCommand(object obj)
        {
            GiaoDichTable = GiaoDichBUS.SapXepXaTruoc(GiaoDichTable);
        }
        private void ExecuteAddNewBillCommand(object obj)
        {
            EditDialogViewModel viewModel = new EditDialogViewModel();
            EditDialog newBillDialog = new EditDialog { DataContext = viewModel };
            newBillDialog.ShowDialog();
            ReloadTable();
        }
        private void ExecuteDeleteChoosenBillCommand(object obj)
        {
            if (GiaoDichTable.Any(gd => gd.IsChecked))
            {
                bool check = false;
                YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Xác nhận", "Bạn có muốn xóa những giao dịch này không?");
                dialogViewModel.DialogClosed += result =>
                {
                    if (result == DialogResult.OK)
                    {
                        check = true;
                    }
                };
                YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                if (check)
                {
                    GiaoDichBUS.XoaNhieuGiaoDich(GiaoDichTable);
                    ReloadTable();
                }
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Chưa chọn giao dịch", "Vui lòng chọn giao dịch để xóa");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
        private void ExecuteShowInfoBillCommand(object obj)
        {
            if (obj is GiaoDichModel selectedRow)
            {
                DetailDialogViewModel viewModel = new DetailDialogViewModel(selectedRow);
                DetailDialog detailDialog = new DetailDialog { DataContext = viewModel };
                detailDialog.ShowDialog();
            }
            ReloadTable();
        }
        private void ExecuteDeleteSingleBillCommand(object obj)
        {
            bool check = false;
            YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Xác nhận", "Bạn có muốn xóa giao dịch này không?");
            dialogViewModel.DialogClosed += result =>
            {
                if (result == DialogResult.OK)
                {
                    check = true;
                }
            };
            YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
            messageBox.ShowDialog();

            if (check)
            {
                if (obj is GiaoDichModel selectedRow)
                {
                    GiaoDichBUS.XoaGiaoDich(selectedRow.MaGD);
                }
                ReloadTable();
            }

        }
        private void ExecuteUpdateIsAllSelectedCommand(object obj)
        {
            System.Windows.Controls.CheckBox checkBox = obj as System.Windows.Controls.CheckBox;
            if (checkBox.Name == "HeaderCheckBox")
            {
                foreach (GiaoDichModel row in GiaoDichTable)
                {
                    row.IsChecked = IsAllSelected;
                    row.OnPropertyChanged(nameof(row.IsChecked));
                }
            }
            else
            {
                IsAllSelected = GiaoDichTable.All(gd => gd.IsChecked);
                OnPropertyChanged(nameof(IsAllSelected));
            }
        }
    }
}
