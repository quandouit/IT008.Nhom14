﻿using QuanLyChiTieu.Data.BUS;
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
        public PlanThisMonthViewModel()
        {
            NgayHomNay();
            ThoiHanSuDung();
            ExecuteUpdateMaxCommand();
            ExecuteUpdateUsedCommand(TienNganSach);
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
        private void ExecuteUpdateMaxCommand()
        {
            TienNganSach = NganSachBUS.TienNganSach();
        }
        private void ExecuteUpdateUsedCommand(decimal tienngansach)
        {
            TienDaDung = NganSachBUS.TienDaDung(tienngansach);
        }
    }
}
