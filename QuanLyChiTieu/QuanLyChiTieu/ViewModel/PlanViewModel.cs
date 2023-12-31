using System;
using QuanLyChiTieu.View.CustomDialog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;
using QuanLyChiTieu.Data.BUS;
using System.Windows.Media.Media3D;


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
        private string _notify;
        public string Notify
        {
            get
            {
                return _notify;
            }

            set
            {
                _notify = value;
                OnPropertyChanged(nameof(Notify));
            }
        }
        
        private List<DateTime> _allHSD;
        public List<DateTime> AllHSD
        {
            get
            {
                return _allHSD;
            }

            set
            {
                _allHSD = value;
                OnPropertyChanged(nameof(AllHSD));
            }
        }

        public ICommand AddingButoonCommand { get; set; }
        public ICommand ShowPlanThisMonthCommand { get; set; }
        public ICommand ViewAllCommand { get; set; }

        public PlanViewModel()
        {
            LoadAllHSD();
            AddingButoonCommand = new ViewModelCommand(ExecuteAddingButoonCommand);
            ShowPlanThisMonthCommand = new ViewModelCommand(ExecuteShowPlanThisMonthCommand);
            ViewAllCommand = new ViewModelCommand(ExecuteViewAllCommand);
            ExecuteShowPlanThisMonthCommand(null);
        }

        private void LoadAllHSD()
        {
            AllHSD = NganSachBUS.HSDNganSach();
        }

        private void ExecuteViewAllCommand(object obj)
        {
            AllPlanView = new AllPlanViewModel();
        }

        private void ExecuteShowPlanThisMonthCommand(object obj)
        {
            DateTime dateTime = DateTime.Now;
            bool flag = false;
            foreach(DateTime date in AllHSD)
            {
                if (dateTime.Month.ToString() == "12"/*date.Month*/ && dateTime.Year.ToString() == "2023"/*date.Year*/)
                { 
                    flag = true; 
                    break; 
                }
            }
            
            if (flag)
            {
                CurrentMonthView = new PlanThisMonthViewModel();
            }
            else
            {
                Notify = "Chưa có ngân sách nào trong tháng này!";
            } 
                
        }
        private void ExecuteAddingButoonCommand(object obj)
        {
            AddingNewPlan addingDialog = new AddingNewPlan();
            addingDialog.ShowDialog();
        }

    }
}