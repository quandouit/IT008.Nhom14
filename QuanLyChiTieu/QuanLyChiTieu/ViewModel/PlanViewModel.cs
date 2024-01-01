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
        //private ViewModelBase _allPlanView;
        //public ViewModelBase AllPlanView
        //{
        //    get
        //    {
        //        return _allPlanView;
        //    }
        //    set
        //    {
        //        _allPlanView = value;
        //        OnPropertyChanged(nameof(AllPlanView));
        //    }
        //}

        //notify: luu thong bao khi thang hien tai khong co ngan sach nao
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
        //All HSD: Chua danh sach cac thang co ngan sach, dugn de kiem tra
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
        //Ngan sach cua thang hien tai
        private decimal _tienNganSach;
        public decimal TienNganSach
        {
            get { return _tienNganSach; }
            set
            {
                _tienNganSach = value;
                OnPropertyChanged(nameof(TienNganSach));
            }
        }
        //So tien da dung trong thang
        private decimal _tienDaDung;
        public decimal TienDaDung
        {
            get { return _tienDaDung; }
            set
            {
                _tienDaDung = value;
                OnPropertyChanged(nameof(TienDaDung));
            }
        }
        //So tien con lai
        private decimal _tienConLai;
        public decimal TienConLai
        {
            get { return _tienConLai; }
            set
            {
                _tienConLai = value;
                OnPropertyChanged(nameof(TienConLai));
            }
        }
        //Ngay hien tai
        private string _homNay;
        public string HomNay
        {
            get { return _homNay; }
            set
            {
                _homNay = value;
                OnPropertyChanged(nameof(HomNay));
            }
        }
        //HSD: Ngay dau thang -> ngay cuoi thang
        private string _hanSuDung;
        public string HanSuDung
        {
            get { return _hanSuDung; }
            set
            {
                _hanSuDung = value;
                OnPropertyChanged(nameof(HanSuDung));
            }
        }
        //Thong bao khi tien su dung > tien ngan sach
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

        public ICommand AddingButtonCommand { get; set; }
        public ICommand ShowPlanThisMonthCommand { get; set; }
        public ICommand ViewAllCommand { get; set; }

        public PlanViewModel()
        {
            if (SharedPlanList == null)
            {
                LoadAllNganSach();
            }

            LoadAllHSD();
            AddingButtonCommand = new ViewModelCommand(ExecuteAddingButtonCommand);
            ShowPlanThisMonthCommand = new ViewModelCommand(ExecuteShowPlanThisMonthCommand);
            ViewAllCommand = new ViewModelCommand(ExecuteViewAllCommand);
            NgayHomNay();
            ThoiHanSuDung();
            ExecuteUpdateMaxCommand();
            ExecuteUpdateUsedCommand(TienNganSach);
            SoTienConLai();
            ShowOverBudgetNotify();
            ExecuteShowPlanThisMonthCommand(null);
        }

        private void LoadAllHSD()
        {
            AllHSD = NganSachBUS.HSDNganSach();
        }

        private void ExecuteViewAllCommand(object obj)
        {
            var mainViewModel = ViewModelLocator.Instance.MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.CurrentChildView = new AllPlanViewModel();
            }
        }

        private void ExecuteShowPlanThisMonthCommand(object obj)
        {
            DateTime dateTime = DateTime.Now;
            bool flag = false;
            foreach(DateTime date in AllHSD)
            {
                if (dateTime.Month == date.Month && dateTime.Year == date.Year)
                { 
                    flag = true; 
                    break; 
                }
            }
            
            if (flag)
            {
                //Status = "Hidden";
            }
            else
            {
                Status = "Hidden";
                Notify = "Chưa có ngân sách nào trong tháng này!";
            } 
                
        }
        private void ExecuteAddingButtonCommand(object obj)
        {
            AddingNewPlan addingDialog = new AddingNewPlan();
            addingDialog.ShowDialog();
        }

        private void ShowOverBudgetNotify()
        {
            if (TienNganSach < TienDaDung)
                OverBudgetNotify = "*Bạn đã vượt quá ngân sách tháng này";
        }

        private void SoTienConLai()
        {
            TienConLai = TienNganSach - TienDaDung;
        }

        private void ThoiHanSuDung()
        {
            DateTime dateTime = DateTime.Now;
            HanSuDung = "1" + "/" + dateTime.Month.ToString() + " - " +
                DateTime.DaysInMonth(dateTime.Year, dateTime.Month) + "/" + dateTime.Month.ToString();
        }

        private void NgayHomNay()
        {
            DateTime dateTime = DateTime.Now;
            HomNay = dateTime.Day.ToString() + "/" + dateTime.Month.ToString();

        }
        private void ExecuteUpdateMaxCommand()
        {
            TienNganSach = NganSachBUS.TienNganSach(DateTime.Now);
        }
        private void ExecuteUpdateUsedCommand(decimal tienngansach)
        {
            int id = MainViewModel.currentUser.ID;
            DateTime dateTime = DateTime.Now;
            TienDaDung = NguoiDungBUS.LayTongChi(id, dateTime.Month, dateTime.Year);
        }

    }
}