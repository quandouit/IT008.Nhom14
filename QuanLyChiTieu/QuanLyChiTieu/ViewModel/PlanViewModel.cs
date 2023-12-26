using System;
using QuanLyChiTieu.View.CustomDialog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;


namespace QuanLyChiTieu.ViewModel
{
    public class PlanViewModel : ViewModelBase
    {
        private ViewModelBase monthcurrent;
        public ViewModelBase CurrentMonthView
        {
            get
            {
                return monthcurrent;
            }

            set
            {
                monthcurrent = value;
                OnPropertyChanged(nameof(CurrentMonthView));
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

        public ICommand AddingButoonCommand { get; set; }
        public ICommand ShowPlanThisMonthCommand { get; set; }
        public ICommand ViewAllCommand { get; set; }

        public PlanViewModel()
        {
            AddingButoonCommand = new ViewModelCommand(ExecuteAddingButoonCommand);
            ShowPlanThisMonthCommand = new ViewModelCommand(ExecuteShowPlanThisMonthCommand);
            ViewAllCommand = new ViewModelCommand(ExecuteViewAllCommand);
            ExecuteShowPlanThisMonthCommand(null);
        }

        private void ExecuteViewAllCommand(object obj)
        {
            AllPlanView = new AllPlanViewModel();
        }

        private void ExecuteShowPlanThisMonthCommand(object obj)
        {
            DateTime dateTime = DateTime.Now;
            if (dateTime.Month.ToString() == "12")
            {
                CurrentMonthView = new PlanThisMonthViewModel();
            }    
        }
        private void ExecuteAddingButoonCommand(object obj)
        {
            AddingNewPlan addingDialog = new AddingNewPlan();
            addingDialog.ShowDialog();
        }

    }
}