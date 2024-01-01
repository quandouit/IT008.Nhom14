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
using System.Windows;
using QuanLyChiTieu.Helper;
using QuanLyChiTieu.ViewModel.CustomDialogModel;


namespace QuanLyChiTieu.ViewModel
{
    public class PlanViewModel : SharePlanListViewModel
    {
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
        //status: trang thai hien hay khong hien border chua ngan sach cua thang hien tai
        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string _overBudgetNotify;
        public string OverBudgetNotify
        {
            get
            {
                return _overBudgetNotify;
            }

            set
            {
                _overBudgetNotify = value;
                OnPropertyChanged(nameof(OverBudgetNotify));
            }
        }
        private decimal _tienConLai;
        public decimal TienConLai
        {
            get { return _tienConLai; }
            set
            {
                _tienConLai = value;
                OnPropertyChanged("TienConLai");
            }
        }
        private decimal _tienDaDung;
        public decimal TienDaDung
        {
            get { return _tienDaDung; }
            set
            {
                _tienDaDung = value;
                OnPropertyChanged("TienDaDung");
            }
        }
        public DateTime Today { get; set; }
        public string FormattedHSD
        {
            get
            {
                if (SharedCurrentInstance != null)
                {
                    DateTime hsd = SharedCurrentInstance.HSD;
                    DateTime startOfMonth = new DateTime(hsd.Year, hsd.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                    return startOfMonth.ToString("d/M/yyyy") + " - " + endOfMonth.ToString("d/M/yyyy");
                }
                return "";
            }
        }
        public ICommand ViewAllCommand { get; set; }
        public ICommand ShowAddingView {  get; set; }

        public PlanViewModel()
        {
            UpdateToday();
            LoadAllNganSach();

            if (SharedPlanList == null)
            {
                LoadAllNganSach();
            }

            if (SharedCurrent == null)
            {
                LoadCurrent(Today);
            }

            OnPropertyChanged("FormattedHSD");

            if (CheckStatus())
            {
                UpdateUsed();
                UpdateRemain();
            }

            ViewAllCommand = new ViewModelCommand(ExecuteViewAllCommand);
            ShowAddingView = new ViewModelCommand(ExecuteShowAddingCommand);
        }
        private void ExecuteShowAddingCommand(object obj)
        {
            AddingNewPlan newPlanDialog = new AddingNewPlan();
            newPlanDialog.ShowDialog();
            LoadAllNganSach();
            LoadCurrent(SharedCurrentInstance.HSD);
            UpdateUsed();
            UpdateRemain();
        }

        private void ExecuteViewAllCommand(object obj)
        {
            var mainViewModel = ViewModelLocator.Instance.MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentChildView = new AllPlanViewModel();
            }
        }
        private void UpdateToday()
        {
            Today = DateTime.Now;
        }
        private void UpdateUsed()
        {
            TienDaDung = NguoiDungBUS.LayTongChi(MainViewModel.currentUser.ID, SharedCurrentInstance.HSD.Month, SharedCurrentInstance.HSD.Year);
        }
        private void UpdateRemain()
        {
            TienConLai = SharedCurrentInstance.TienNS - TienDaDung;
            if (TienDaDung > SharedCurrent.TienNS)
                OverBudgetNotify = "Bạn đã vượt quá ngân sách!";
            else OverBudgetNotify = "";
        }
        private bool CheckStatus()
        {
            if (SharedCurrentInstance == null)
            {
                Notify = "Chưa có ngân sách nào trong tháng này";
                Status = "Hidden";
                return false;
            }
            Notify = "";
            Status = "";
            return true;
        }
    }
}