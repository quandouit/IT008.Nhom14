using FontAwesome.Sharp;
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
    public class MonthYear
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public MonthYear(int month = 0, int year = 0) 
        {
            Month = month;
            Year = year;
        }
        public bool isEmpty()
        {
            if (Month == 0 && Year == 0) 
                return true; 
            return false;
        }
    }
    public class HomeViewModel : ViewModelBase
    {
        public static List<LoaiGiaoDichDTO> ListLoaiGiaoDich { get; private set; }
        public int Year { get; set; }
        public MonthYear MonthWithYear { get; set; }

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
            ListLoaiGiaoDich = GiaoDichBUS.LietKeLoaiGiaoDich();
            Year = 0;
            MonthWithYear = new MonthYear();
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
