using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel
{
    public class PlanThisMonthViewModel : ViewModelBase
    {
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
        public PlanThisMonthViewModel()
        {
            NgayHomNay();
            ThoiHanSuDung();
            ExecuteUpdateMaxCommand();
            ExecuteUpdateUsedCommand(TienNganSach);
            SoTienConLai();
            ShowOverBudgetNotify();
        }

        private void ShowOverBudgetNotify()
        {
            if(TienNganSach < TienDaDung)
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
            TienNganSach = NganSachBUS.TienNganSach();
        }
        private void ExecuteUpdateUsedCommand(decimal tienngansach)
        {
            int id = MainViewModel.currentUser.ID;
            DateTime dateTime = DateTime.Now;
            TienDaDung = NguoiDungBUS.LayTongChi(id, dateTime.Month, dateTime.Year);
        }
    }
}
