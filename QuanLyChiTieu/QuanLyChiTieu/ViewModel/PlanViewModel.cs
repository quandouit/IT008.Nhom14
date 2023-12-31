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
using System.Windows.Data;
using QuanLyChiTieu.Model;
using System.ComponentModel;


namespace QuanLyChiTieu.ViewModel
{
    public class PlanViewModel : ViewModelBase
    {
        private ViewModelBase monthcurrent;
        private NganSachModel _nganSachHienTai;
        public NganSachModel NganSachHienTai
        {
            get
            {
                return _nganSachHienTai;
            }

            set
            {
                _nganSachHienTai = value;
                OnPropertyChanged(nameof(NganSachHienTai));
            }
        }
        private BindingList<NganSachModel> _danhSachNganSach;
        public BindingList<NganSachModel> DanhSachNganSach
        {
            get
            {
                return _danhSachNganSach;
            }

            set
            {
                _danhSachNganSach = value;
                OnPropertyChanged(nameof(DanhSachNganSach));
            }
        }
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
        public ICommand AddingButtonCommand { get; set; }
        public ICommand ShowPlanThisMonthCommand { get; set; }
        public ICommand ViewAllCommand { get; set; }

        public PlanViewModel()
        {
            LoadAllHSD();
            AddingButtonCommand = new ViewModelCommand(ExecuteAddingButtonCommand);
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
            Notify = "";
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
        private void ExecuteAddingButtonCommand(object obj)
        {
            AddingNewPlan addingDialog = new AddingNewPlan();
            addingDialog.ShowDialog();
        }

    }
}