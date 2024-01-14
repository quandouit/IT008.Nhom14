using LiveCharts;
using LiveCharts.Wpf;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Helper;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class MonthChartViewModel : ViewModelBase
    {
        private List<LoaiGiaoDichDTO> outputIn {  get; set; }
        private List<LoaiGiaoDichDTO> outputOut { get; set; }
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
            GetSum();
            ShowChart();
        }
        private void ExecuteChooseMonthCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new ChooseMonthViewModel();
        }
        private void ShowChart()
        {
            //Biểu đồ tròn phân tích các khoản chi

            if (outputOut.Any(lgd => lgd.SumTIEN > 0))
            {
                MyPieChartData = new SeriesCollection();
                foreach (LoaiGiaoDichDTO item in outputOut)
                {
                    if (item.SumTIEN > 0)
                    {
                        PieSeries pie = new PieSeries
                        {
                            Title = item.TenLoaiGD,
                            Values = new ChartValues<double> { (double)item.SumTIEN }
                        };
                        MyPieChartData.Add(pie);
                    }
                }
                PieChart1DataCanShow = true;
            }
            else
            {
                PieChart1DataCanShow = false;
            }

            //Biểu đồ tròn phân tích các khoản thu
            if (outputIn.Any(lgd => lgd.SumTIEN > 0))
            {
                MyPieChartData2 = new SeriesCollection();
                foreach (LoaiGiaoDichDTO item in outputIn)
                {
                    if (item.SumTIEN > 0)
                    {
                        PieSeries pie = new PieSeries
                        {
                            Title = item.TenLoaiGD,
                            Values = new ChartValues<double> { (double)item.SumTIEN }
                        };
                        MyPieChartData2.Add(pie);
                    }
                }
                PieChart2DataCanShow = true;
            }
            else
            {
                PieChart2DataCanShow = false;
            }
        }
        private void GetSum()
        {
            outputIn = HomeViewModel.ListLoaiGiaoDich.Where(lgd => lgd.TrangThai == "IN").Select(lgd => lgd.DeepCopy()).ToList();
            outputOut = HomeViewModel.ListLoaiGiaoDich.Where(lgd => lgd.TrangThai == "OUT").Select(lgd => lgd.DeepCopy()).ToList();

            foreach (var giaoDich in MainViewModel.listGiaoDich)
            {
                if (giaoDich.NgayTao.Month == SelectedMonth.Month && giaoDich.NgayTao.Year == SelectedMonth.Year)
                {
                    if (giaoDich.TrangThai == "IN")
                    {
                        var loaiGiaoDich = outputIn.FirstOrDefault(lgd => lgd.MaLoaiGD == giaoDich.MaLoaiGD);
                        if (loaiGiaoDich != null)
                        {
                            loaiGiaoDich.SumTIEN += giaoDich.Tien;
                        }
                    }
                    else if (giaoDich.TrangThai == "OUT")
                    {
                        var loaiGiaoDich = outputOut.FirstOrDefault(lgd => lgd.MaLoaiGD == giaoDich.MaLoaiGD);
                        if (loaiGiaoDich != null)
                        {
                            loaiGiaoDich.SumTIEN += giaoDich.Tien;
                        }
                    }
                }
            }
        }
    }
}
