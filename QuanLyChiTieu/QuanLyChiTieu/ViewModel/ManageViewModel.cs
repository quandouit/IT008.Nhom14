using QuanLyChiTieu.Data.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.ViewModel
{
    public class ManageViewModel : ViewModelBase
    {
        public DataTable GiaoDichData { get; set; }

        public ManageViewModel()
        {
            LoadGiaoDichData();
        }

        public void LoadGiaoDichData()
        {
            GiaoDichData = GiaoDichBUS.LietKeGiaoDich();
            OnPropertyChanged(nameof(GiaoDichData));
        }
    }
}
