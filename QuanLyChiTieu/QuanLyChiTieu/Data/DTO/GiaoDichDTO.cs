using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.ViewModel;
using QuanLyChiTieu.ViewModel.CustomDialogModel;

namespace QuanLyChiTieu.Data.DTO
{
    public class GiaoDichDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public GiaoDichDTO() { }
        public int MaGD { get; set; }
        public int ID { get; set; }
        public int MaLoaiGD { get; set; }
        private string _tenGD;
        public string TenGD
        {
            get { return _tenGD; }
            set
            {
                if (_tenGD != value)
                {
                    _tenGD = value;
                    if (!EditDialogViewModel._isAutoFill)
                    {
                        EditDialogViewModel._isUserInput = true;
                    }
                    OnPropertyChanged(nameof(TenGD));
                }
            }
        }
        public decimal Tien { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public bool IsFilled()
        {
            if (string.IsNullOrEmpty(MaLoaiGD.ToString()) || MaLoaiGD == 0) { return false; }
            if (string.IsNullOrWhiteSpace(TenGD)) { return false; }
            if (string.IsNullOrWhiteSpace(Tien.ToString())) { return false; }
            return true;
        }
    }
}
