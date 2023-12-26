using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class AllPlanViewModel : ViewModelBase
    {
        private ViewModelBase _planView;
        public ViewModelBase PlanView
        {
            get
            {
                return _planView;
            }

            set
            {
                _planView = value;
                OnPropertyChanged(nameof(PlanView));
            }
        }

        private ViewModelBase _allPlanView;
        public ViewModelBase AllPlanView
        {
            get
            {
                return _allPlanView;
            }

            set
            {
                _allPlanView = value;
                OnPropertyChanged(nameof(AllPlanView));
            }
        }

        public ICommand TurnBackCommand { get; set; }

        public AllPlanViewModel()
        {
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
            //ExecuteShowPlanThisMonthCommand(null);
        }

        private void ExecuteTurnBackCommand(object obj)
        {
            PlanView = new PlanViewModel();
        }
    }
}
