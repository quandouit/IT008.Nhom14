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
using System.Data.Common;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View.CustomDialog;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class DetailDialogViewModel : ViewModelBase
    {
        public GiaoDichModel GiaoDich { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand CloseCommand { get; }
        public DetailDialogViewModel(GiaoDichModel input)
        {
            GiaoDich = input;

            EditCommand = new ViewModelCommand(ExecuteEditCommand);
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
        private void ExecuteEditCommand(object obj)
        {
            if (obj is Window window)
            {
                EditDialogViewModel viewModel = new EditDialogViewModel(GiaoDich);
                EditDialog editDialog = new EditDialog { DataContext = viewModel };
                window.Close();
                var mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
                mainWindow.Hide();
                editDialog.ShowDialog();
                mainWindow.Show();
            }
        }
    }
}
