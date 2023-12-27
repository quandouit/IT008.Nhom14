using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.ViewModel
{
    public class PlanThisMonthViewModel : ViewModelBase
    {
        private string _tienNganSach;
        public string TienNganSach
        {
            get { return _tienNganSach; }
            set
            {
                _tienNganSach = value;
                OnPropertyChanged(nameof(TienNganSach));
            }
        }

        private string _tienDaDung;
        public string TienDaDung
        {
            get { return _tienDaDung; }
            set
            {
                _tienDaDung = value;
                OnPropertyChanged(nameof(TienDaDung));
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
        private decimal soNguyenTienNganSach;
        public decimal SoNguyenTienNganSach
        {
            get { return soNguyenTienNganSach; }
            set
            {
                soNguyenTienNganSach = value;
                OnPropertyChanged(nameof(SoNguyenTienNganSach));
            }
        }
        private decimal soNguyenTienDaDung;
        public decimal SoNguyenTienDaDung
        {
            get { return soNguyenTienDaDung; }
            set
            {
                soNguyenTienDaDung = value;
                OnPropertyChanged(nameof(SoNguyenTienDaDung));
            }
        }

        public PlanThisMonthViewModel()
        {
            HienThiTienNganSach();
            HienThiTienDaDung();
            NgayHomNay();
            ThoiHanSuDung();
            TinhTienNganSach();
            TinhTienDaDung();
        }

        private void TinhTienDaDung()
        {
            SoNguyenTienDaDung = decimal.Parse(TienNganSach) - decimal.Parse(TienDaDung);
        }

        private void TinhTienNganSach()
        {
            SoNguyenTienNganSach = decimal.Parse(TienNganSach);
        }

        private void ThoiHanSuDung()
        {
            DateTime dateTime = DateTime.Now;
            HomNay = dateTime.Day.ToString() + "/" + dateTime.Month.ToString();
        }

        private void NgayHomNay()
        {
            DateTime dateTime = DateTime.Now;
            HanSuDung = "1" + "/" + dateTime.Month.ToString() + " - " +
                DateTime.DaysInMonth(dateTime.Year, dateTime.Month) + "/" + dateTime.Month.ToString();

        }

        private void HienThiTienDaDung()
        {
            TienDaDung = NganSachBUS.TienDaDung();
        }

        private void HienThiTienNganSach()
        {
            TienNganSach = NganSachBUS.TienNganSach();
        }


    }
}
