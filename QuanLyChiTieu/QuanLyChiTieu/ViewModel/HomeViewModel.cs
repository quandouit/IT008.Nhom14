using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SoDu = NguoiDungBUS.LaySoDu(MainViewModel.currentUser.ID);
            
            //lấy tháng và năm hiện tại để lấy khoản thu chi;
            DateTime dateTime = DateTime.Now;

            MyChartData = new SeriesCollection
            {
            new ColumnSeries
            {
                Title = "Giá trị",
                Values = new ChartValues<int> { 20, 30, 20, 40 }
            }
            };

            Categories = new[] { "Thu tháng trước", "Chi tháng trước", "Thu tháng này " ,"Chi tháng này"};
        }
    }
}
