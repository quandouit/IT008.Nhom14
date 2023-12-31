using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace QuanLyChiTieu.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
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

        public HomeViewModel()
        {
            int id = MainViewModel.currentUser.ID;
            SoDu = NguoiDungBUS.LaySoDu(id);

            //lấy tháng và năm hiện tại để lấy khoản thu chi;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;


            decimal TongChiThangNay = NguoiDungBUS.LayTongChi(id, month, year);
            decimal TongThuThangNay = NguoiDungBUS.LayTongThu(id, month, year);

            //tìm tháng trước để lấy khoản thu chi
            if (month == 1) { month = 12; year--; }
            else month--;
            decimal TongChiThangTruoc = NguoiDungBUS.LayTongChi(id, month, year);
            decimal TongThuThangTruoc = NguoiDungBUS.LayTongThu(id, month, year);

            ColumnSeries columnSeries1 = new ColumnSeries
            {
                Title = "Thu",
                Values = new ChartValues<decimal> { TongThuThangTruoc, TongThuThangNay },
                Fill = (Brush)System.Windows.Application.Current.Resources["greenUI"]
            };
            ColumnSeries columnSeries2 = new ColumnSeries
            {
                Title = "Chi",
                Values = new ChartValues<decimal> { TongChiThangTruoc, TongChiThangNay },
                Fill = (Brush)System.Windows.Application.Current.Resources["redUI"]
            };

            // Thêm chuỗi dữ liệu vào biểu đồ
            MyChartData = new SeriesCollection { };
            if ((int)(TongThuThangTruoc + TongThuThangNay + TongChiThangTruoc + TongChiThangNay) != 0)
            {
                // Nếu có dữ liệu, thêm chuỗi dữ liệu vào biểu đồ
                MyChartData = new SeriesCollection { columnSeries1, columnSeries2 };
                MyChartDataCanShow = true;
            }
            else
            {
                MyChartDataCanShow = false;
            }

            Categories = new[] { "Tháng trước", "Tháng này" };

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
    }
}
