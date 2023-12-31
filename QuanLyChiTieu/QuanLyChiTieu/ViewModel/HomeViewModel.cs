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

            
            int TongChiThangNay = (int)NguoiDungBUS.LayTongChi(id, month, year);
            int TongThuThangNay = (int)NguoiDungBUS.LayTongThu(id, month, year);

            //tìm tháng trước để lấy khoản thu chi
            if (month == 1) { month = 12; year--; }
            else month--;
            int TongChiThangTruoc = (int)NguoiDungBUS.LayTongChi(id, month, year);
            int TongThuThangTruoc = (int)NguoiDungBUS.LayTongThu(id, month, year);

            MyChartData = new SeriesCollection
            {
            new ColumnSeries
            {
                Title = "Giá trị",
                Values = new ChartValues<int> { TongThuThangTruoc, TongChiThangTruoc, TongThuThangNay, TongChiThangNay }
            }
            };

            Categories = new[] { "Thu tháng trước", "Chi tháng trước", "Thu tháng này " ,"Chi tháng này"};

            //Biểu đồ tròn phân tích các khoản chi
            List<LoaiGiaoDichDTO> myList = GiaoDichBUS.PhanLoaiGiaoDichOUT();

            MyPieChartData = new SeriesCollection();
            foreach(LoaiGiaoDichDTO item  in myList)
            {
                PieSeries pie = new PieSeries
                {
                    Title = item.TenLoaiGD,
                    Values = new ChartValues<double> { (double)item.SumTIEN }
                };
                MyPieChartData.Add(pie);
            }

            //Biểu đồ tròn phân tích các khoản thu
            myList = GiaoDichBUS.PhanLoaiGiaoDichIN();

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
        }
    }
}
