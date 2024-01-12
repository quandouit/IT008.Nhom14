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
        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    // Handle the selected year change if needed
                    ShowChart(selectedMonth, selectedYear);
                }
            }
        }
        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                if (selectedMonth != value)
                {
                    selectedMonth = value;
                    // Handle the selected year change if needed
                    ShowChart(selectedMonth, selectedYear);
                }
            }
        }
        public ICommand ChooseMonthCommand { get; set; }
        public MonthChartViewModel()
        {
            ChooseMonthCommand = new ViewModelCommand(ExecuteChooseMonthCommand);

            //mặc định tháng/năm là thời gian hiện tại
            //thay đổi tháng hoặc năm sẽ cập nhật lại biểu đồ
            SelectedMonth = DateTime.Now.Month;
            SelectedYear = DateTime.Now.Year;
        }
        private void ExecuteChooseMonthCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new ChooseMonthViewModel();
        }
        private void ShowChart(int month, int year)
        {
            //Biểu đồ tròn phân tích các khoản chi
            List<LoaiGiaoDichDTO> myList = GiaoDichBUS.PhanLoaiGiaoDichOUT(month, year);

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
            myList = GiaoDichBUS.PhanLoaiGiaoDichIN(month, year);
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
