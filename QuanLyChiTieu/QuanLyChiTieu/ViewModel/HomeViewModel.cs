using FontAwesome.Sharp;
using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
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
        private ViewModelBase yearChartCurrent;
        public ViewModelBase YearChartView
        {
            get
            {
                return yearChartCurrent;
            }

            set
            {
                yearChartCurrent = value;
                OnPropertyChanged(nameof(YearChartView));
            }
        }
        private ViewModelBase monthChartCurrent;
        public ViewModelBase MonthChartView
        {
            get
            {
                return monthChartCurrent;
            }

            set
            {
                monthChartCurrent = value;
                OnPropertyChanged(nameof(MonthChartView));
            }
        }
        private bool _pieChart1DataCanShow;
        public bool PieChart1DataCanShow
        {
            get { return _pieChart1DataCanShow; }
            set
            {
                _pieChart1DataCanShow = value;
                OnPropertyChanged(nameof(PieChart1DataCanShow));
            }
        }
        private bool _pieChart2DataCanShow;
        public bool PieChart2DataCanShow
        {
            get { return _pieChart2DataCanShow; }
            set
            {
                _pieChart2DataCanShow = value;
                OnPropertyChanged(nameof(PieChart2DataCanShow));
            }
        }
        private SeriesCollection _myPieChartData;
        public SeriesCollection MyPieChartData
        {
            get { return _myPieChartData; }
            set
            {
                _myPieChartData = value;
                OnPropertyChanged(nameof(MyPieChartData));
            }
        }
        private SeriesCollection _myPieChartData2;
        public SeriesCollection MyPieChartData2
        {
            get { return _myPieChartData2; }
            set
            {
                _myPieChartData2 = value;
                OnPropertyChanged(nameof(MyPieChartData2));
            }
        }
        public ICommand ShowYearViewCommand { get; }
        public ICommand ShowMonthViewCommand { get; }

        public HomeViewModel()
        {
            ShowYearViewCommand = new ViewModelCommand(ExecuteShowYearViewCommand);
            ShowMonthViewCommand = new ViewModelCommand(ExecuteShowMonthViewCommand);
            ExecuteShowYearViewCommand(null);
            ExecuteShowMonthViewCommand(null);

            SoDu = NguoiDungBUS.LaySoDu(MainViewModel.currentUser.ID);

            //Biểu đồ tròn phân tích các khoản chi
            List<LoaiGiaoDichDTO> myList = GiaoDichBUS.PhanLoaiGiaoDichOUT();

            if (myList.Count > 0)
            {
                MyPieChartData = new SeriesCollection();
                foreach (LoaiGiaoDichDTO item in myList)
                {
                    PieSeries pie = new PieSeries
                    {
                        Title = item.TenLoaiGD,
                        Values = new ChartValues<double> { (double)item.SumTIEN }
                    };
                    MyPieChartData.Add(pie);
                }
                PieChart1DataCanShow = true;
            }
            else
            {
                PieChart1DataCanShow = false;
            }

            //Biểu đồ tròn phân tích các khoản thu
            myList = GiaoDichBUS.PhanLoaiGiaoDichIN();
            if (myList.Count > 0)
            {
                MyPieChartData2 = new SeriesCollection();
                foreach (LoaiGiaoDichDTO item in myList)
                {
                    PieSeries pie = new PieSeries
                    {
                        Title = item.TenLoaiGD,
                        Values = new ChartValues<double> { (double)item.SumTIEN }
                    };
                    MyPieChartData2.Add(pie);
                }
                PieChart2DataCanShow = true;
            }
            else
            {
                PieChart2DataCanShow = false;
            }
        }

        private void ExecuteShowYearViewCommand(object obj)
        {
            YearChartView = new CustomDialogModel.YearChartViewModel();
        }
        private void ExecuteShowMonthViewCommand(object obj)
        {
            MonthChartView = new CustomDialogModel.MonthChartViewModel();
        }
    }
}
