using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class MonthChartViewModel : ViewModelBase
    {
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
        public MonthYear SelectedMonth
        {
            get { return ViewModelLocator.Instance.HomeViewModel.MonthWithYear; }
            set
            {
                if (ViewModelLocator.Instance.HomeViewModel.MonthWithYear != value)
                {
                    ViewModelLocator.Instance.HomeViewModel.MonthWithYear = value;
                }
            }
        }
        public ICommand ChooseMonthCommand { get; set; }
        public MonthChartViewModel()
        {
            ChooseMonthCommand = new ViewModelCommand(ExecuteChooseMonthCommand);
            if (ViewModelLocator.Instance.HomeViewModel.MonthWithYear.isEmpty())
            {
                SelectedMonth = new MonthYear(DateTime.Now.Month, DateTime.Now.Year);
            }
            ShowChart(SelectedMonth);
        }
        private void ExecuteChooseMonthCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new ChooseMonthViewModel();
        }
        private void ShowChart(MonthYear obj)
        {
            //Biểu đồ tròn phân tích các khoản chi
            List<LoaiGiaoDichDTO> myList = GiaoDichBUS.PhanLoaiGiaoDichOUT(obj.Month, obj.Year);

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
            myList = GiaoDichBUS.PhanLoaiGiaoDichIN(obj.Month, obj.Year);
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
    }
}
