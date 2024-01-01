using QuanLyChiTieu.Helper;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class YearGroup
    {
        public int Year { get; set; }
        public ObservableCollection<NganSachModel> Months { get; set; }
    }

    public class AllPlanViewModel : SharePlanListViewModel
    {
        public ObservableCollection<YearGroup> YearGroups { get; set; }

        public void GroupByYear()
        {
            var groups = SharedPlanList.GroupBy(x => x.HSD.Year)
                .Select(g => new YearGroup { Year = g.Key, Months = new ObservableCollection<NganSachModel>(g.OrderBy(x => x.HSD).ToList()) })
                .ToList();

            YearGroups = new ObservableCollection<YearGroup>(groups);
        }

        public ICommand TurnBackCommand { get; set; }
        public ICommand UpdateSharedCurrentCommand { get; private set; }
        public AllPlanViewModel()
        {
            GroupByYear();
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
            UpdateSharedCurrentCommand = new ViewModelCommand<NganSachModel>(UpdateSharedCurrent); ;
        }
        private void UpdateSharedCurrent(NganSachModel nganSachModel)
        {
            SharedCurrentInstance = nganSachModel;
            var mainViewModel = ViewModelLocator.Instance.MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentChildView = new PlanViewModel();
            }

        }
        private void ExecuteTurnBackCommand(object obj)
        {
            var mainViewModel = ViewModelLocator.Instance.MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentChildView = new PlanViewModel();
            }
        }
    }
}
