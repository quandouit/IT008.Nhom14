using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DTO
{
    public class NganSachDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NganSachDTO() { }
        public string MaNS { get; set; }
        public int ID { get; set; }
        public string TenNS { get; set; }
        public decimal TienNS { get; set; }
        public DateTime HSD { get; set; }
    }
}
