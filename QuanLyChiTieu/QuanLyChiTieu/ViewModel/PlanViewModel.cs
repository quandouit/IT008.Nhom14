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
        public ICommand AddingButoonCommand { get; set; }
        public ICommand ShowPlanThisMonthCommand { get; set; }

        public PlanViewModel()
        {
            AddingButoonCommand = new ViewModelCommand(ExecuteAddingButoonCommand);
            ShowPlanThisMonthCommand = new ViewModelCommand(ExecuteShowPlanThisMonthCommand);

            ExecuteShowPlanThisMonthCommand(null);
        }

        private void ExecuteShowPlanThisMonthCommand(object obj)
        {
            DateTime dateTime = DateTime.Now;
            if (dateTime.Month.ToString() == "11")
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