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
    public class ChooseYearViewModel : ViewModelBase
    {
        public List<int> ListYear { get; set; }
        public void GetList()
        {
            ListYear = MainViewModel.listGiaoDich
                .Select(gd => gd.NgayTao.Year)
                .Distinct()
                .OrderByDescending(year => year)
                .ToList();
        }
        public ICommand ChangeYearCommand { get; private set; }
        public ICommand TurnBackCommand { get; set; }
        public ChooseYearViewModel()
        {
            GetList();
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
            ChangeYearCommand = new ViewModelCommand<int>(ExecuteChangeYearCommand);
        }
        private void ExecuteTurnBackCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.YearChartView = new YearChartViewModel();
        }
        private void ExecuteChangeYearCommand(int obj)
        {
            ViewModelLocator.Instance.HomeViewModel.Year = obj;

            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.YearChartView = new YearChartViewModel();
        }
    }
}
