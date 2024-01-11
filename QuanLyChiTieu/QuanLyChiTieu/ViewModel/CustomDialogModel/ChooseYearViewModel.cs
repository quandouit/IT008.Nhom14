using QuanLyChiTieu.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class ChooseYearViewModel : ViewModelBase
    {
        public ICommand TurnBackCommand { get; set; }
        public ChooseYearViewModel()
        {
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
        }
        private void ExecuteTurnBackCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.YearChartView = new YearChartViewModel();
        }
    }
}
