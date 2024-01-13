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
    public class MonthYearGroup
    {
        public int Year { get; set; }
        public ObservableCollection<MonthYear> Months { get; set; }
    }
    public class ChooseMonthViewModel : ViewModelBase
    {
        public List<MonthYear> ListMonthYear {  get; set; }
        public ObservableCollection<MonthYearGroup> ListMonthYearGroup { get; set; }
        public void GetList()
        {
            ListMonthYear = MainViewModel.listGiaoDich
                .Select(gd => new MonthYear { Month = gd.NgayTao.Month, Year = gd.NgayTao.Year })
                .GroupBy(tn => new { tn.Month, tn.Year })
                .Select(g => g.First())
                .OrderByDescending(tn => tn.Year)
                .ThenBy(tn => tn.Month)
                .ToList();
        }
        public void GroupByYear()
        {
            var groups = ListMonthYear
                .GroupBy(tn => tn.Year)
                .Select(g => new MonthYearGroup
                {
                    Year = g.Key,
                    Months = new ObservableCollection<MonthYear>(g.OrderBy(tn => tn.Month))
                })
                .ToList();

            ListMonthYearGroup = new ObservableCollection<MonthYearGroup>(groups);
        }
        public ICommand TurnBackCommand { get; set; }
        public ICommand UpdateMonthCommand { get; private set; }
        public ChooseMonthViewModel()
        {
            GetList();
            GroupByYear();
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
            UpdateMonthCommand = new ViewModelCommand<MonthYear>(ExecuteUpdateMonthCommand); ;
        }
        private void ExecuteUpdateMonthCommand(MonthYear obj)
        {
            ViewModelLocator.Instance.HomeViewModel.MonthWithYear = obj;

            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new MonthChartViewModel();
        }
        private void ExecuteTurnBackCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new MonthChartViewModel();
        }
    }
}
