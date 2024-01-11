using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Helper;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View.CustomDialog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class YearItem
    {
        public int Year { get; set; }
    }
    public class YearChartViewModel : ViewModelBase
    {
        //Xử lí ComboBox year
        public ObservableCollection<YearItem> Years { get; set; }
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
                    ShowChart();
                }
            }
        }
        public ICommand ChooseYearCommand { get; set; }
        public YearChartViewModel()
        {
            Years = new ObservableCollection<YearItem>();
            // Populate the ComboBox with a range of years
            for (int y = 2000; y <= DateTime.Now.Year; y++)
            {
                Years.Add(new YearItem { Year = y });
            }

            SelectedYear = DateTime.Now.Year;

            ChooseYearCommand = new ViewModelCommand(ExecuteChooseYearCommand);
        }
        private void ExecuteChooseYearCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.YearChartView = new ChooseYearViewModel();
        }
        //Khai báo dữ liệu biểu đồ
        private int id = MainViewModel.currentUser.ID;
        private BindingList<GiaoDichModel> listGD
        {
            get { return MainViewModel.listGiaoDich; }
            set { } //read_only
        }

        private bool _myChartDataCanShow;
        public bool MyChartDataCanShow
        {
            get { return _myChartDataCanShow; }
            set
            {
                _myChartDataCanShow = value;
                OnPropertyChanged(nameof(MyChartDataCanShow));
            }
        }
        private SeriesCollection _myChartData;
        public SeriesCollection MyChartData
        {
            get { return _myChartData; }
            set
            {
                _myChartData = value;
                OnPropertyChanged(nameof(MyChartData));
            }
        }
        private string[] _categories;
        public string[] Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        private bool haveValue = false;
        private void ShowChart()
        {
            //Xử lí biểu đồ
            LineSeries lineOUT = new LineSeries
            {
                Title = "OUT",
                Values = new ChartValues<decimal> { getOUT(1), getOUT(2), getOUT(3), getOUT(4), getOUT(5), getOUT(6), getOUT(7), getOUT(8), getOUT(9), getOUT(10), getOUT(11), getOUT(12) },
                Stroke = Brushes.Red
            };
            LineSeries lineIN = new LineSeries
            {
                Title = "IN",
                Values = new ChartValues<decimal> { getIN(1), getIN(2), getIN(3), getIN(4), getIN(5), getIN(6), getIN(7), getIN(8), getIN(9), getIN(10), getIN(11), getIN(12), },
                Stroke = Brushes.Green
            };

            // Thêm chuỗi dữ liệu vào biểu đồ
            MyChartData = new SeriesCollection { };
            if (haveValue)
            {
                // Nếu có dữ liệu, thêm chuỗi dữ liệu vào biểu đồ
                MyChartData.Add(lineOUT);
                MyChartData.Add(lineIN);
                
                MyChartDataCanShow = true;
            }
            else
            {
                MyChartDataCanShow = false;
            }

            Categories = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", };
        }
        private decimal getOUT(int month)
        {
            decimal rt = 0;
            foreach (GiaoDichModel item in listGD)
            {
                if (item.TrangThai == "OUT" && item.NgayTao.Month == month && item.NgayTao.Year == selectedYear)
                    rt += item.Tien;
            }
            if (rt != 0) haveValue = true;
            return rt;
        }
        private decimal getIN(int month)
        {
            decimal rt = 0;
            foreach (GiaoDichModel item in listGD)
            {
                if (item.TrangThai == "IN" && item.NgayTao.Month == month && item.NgayTao.Year == selectedYear)
                    rt += item.Tien;
            }
            if (rt != 0) haveValue = true;
            return rt;
        }
    }
}
