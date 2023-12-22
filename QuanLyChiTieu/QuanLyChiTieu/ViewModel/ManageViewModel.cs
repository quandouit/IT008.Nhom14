﻿using QuanLyChiTieu.Data.BUS;
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
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public bool IsAllSelected { get; set; }
        public BindingList<GiaoDichModel> GiaoDichData { get; set; }
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
        }
        private void ExecuteAddNewBillCommand(object obj)
        {
            GiaoDichBUS.ThemGiaoDich();
            GiaoDichData = GiaoDichBUS.LietKeGiaoDich();
        }
        private void ExecuteDeleteChoosenBillCommand(object obj)
        {
            MessageBox.Show("Thuc hien xoa cac giao dich da chon");
        }
        private void ExecuteShowInfoBillCommand(object obj)
        {
            if (obj is GiaoDichModel selectedRow)
            {
                DetailDialogViewModel viewModel = new DetailDialogViewModel(selectedRow);
                DetailDialog detailDialog = new DetailDialog { DataContext = viewModel };
                detailDialog.ShowDialog();
            }
        }

        private void ExecuteDeleteSingleBillCommand(object obj)
        {
            if (obj is DataRowView selectedRow)
            {
                GiaoDichBUS.XoaGiaoDich(selectedRow[0]);
            }

            GiaoDichData = GiaoDichBUS.LietKeGiaoDich();
        }
        private void ExecuteUpdateIsAllSelectedCommand(object obj)
        {
            CheckBox checkBox = obj as CheckBox;
            if (checkBox.Name == "HeaderCheckBox")
            {
                foreach (GiaoDichModel row in GiaoDichData)
                {
                    row.IsChecked = IsAllSelected;
                    row.OnPropertyChanged(nameof(row.IsChecked));
                }
            }
            else
            {
                IsAllSelected = GiaoDichData.All(gd => gd.IsChecked);
                OnPropertyChanged(nameof(IsAllSelected));
            }
        }
    }
}
