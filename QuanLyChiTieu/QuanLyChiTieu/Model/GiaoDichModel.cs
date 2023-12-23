using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace QuanLyChiTieu.Model
{
    public class GiaoDichModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public GiaoDichModel() { }
        public int MaGD { get; set; }
        public int ID { get; set; }
        public string TenLoaiGD { get; set; }
        public string TenGD { get; set; }
        public decimal Tien { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
        public bool IsChecked { get; set; }
        public int STT { get; set; }
        public string TrangThai { get; set; }
    }
}
