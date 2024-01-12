﻿using FontAwesome.Sharp;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Helper;
using QuanLyChiTieu.View.CustomDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace QuanLyChiTieu.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private decimal _soDu;
        public decimal SoDu
        {
            get { return _soDu; }
            set
            {
                _soDu = value;
                OnPropertyChanged(nameof(SoDu));
            }
        }
        private ViewModelBase yearchartcurrent;
        public ViewModelBase YearChartView
        {
            get
            {
                return yearchartcurrent;
            }

            set
            {
                yearchartcurrent = value;
                OnPropertyChanged(nameof(YearChartView));
            }
        }
        private ViewModelBase monthchartcurrent;
        public ViewModelBase MonthChartView
        {
            get
            {
                return monthchartcurrent;
            }

            set
            {
                monthchartcurrent = value;
                OnPropertyChanged(nameof(MonthChartView));
            }
        }
        
        public ICommand ShowYearViewCommand { get; }
        public ICommand ShowMonthViewCommand { get; }

        public HomeViewModel()
        {
            SoDu = NguoiDungBUS.LaySoDu(MainViewModel.currentUser.ID);

            ShowYearViewCommand = new ViewModelCommand(ExecuteShowYearViewCommand);
            ShowMonthViewCommand = new ViewModelCommand(ExecuteShowMonthViewCommand);
            ExecuteShowYearViewCommand(null);
            ExecuteShowMonthViewCommand(null);
        }
        private void ExecuteShowYearViewCommand(object obj)
        {
            ViewModelLocator.Instance.HomeViewModel = this;
            YearChartView = new CustomDialogModel.YearChartViewModel();
        }
        private void ExecuteShowMonthViewCommand(object obj)
        {
            MonthChartView = new CustomDialogModel.MonthChartViewModel();
        }
    }
}
