using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Model
{
    public class NganSachModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal bool IsFilled()
        {
            if (TienNS == 0)
            {
                return false;
            }
            return true;
        }

        public NganSachModel() { }
        public int ID { get; set; }
        public DateTime HSD { get; set; }
        public decimal TienNS { get; set; }
    }
}
