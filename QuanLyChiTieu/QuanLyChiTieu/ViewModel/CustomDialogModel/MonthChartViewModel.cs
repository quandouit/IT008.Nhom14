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
        public ICommand ChooseMonthCommand { get; set; }
        public MonthChartViewModel()
        {
            ChooseMonthCommand = new ViewModelCommand(ExecuteChooseMonthCommand);
        }
        private void ExecuteChooseMonthCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new ChooseMonthViewModel();
        }
    }
}
