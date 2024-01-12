using QuanLyChiTieu.Helper;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class ThangNam
    {
        public int Thang { get; set; }
        public int Nam { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ThangNam)
            {
                var other = obj as ThangNam;
                return this.Thang == other.Thang && this.Nam == other.Nam;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Thang * 10000 + Nam;
        }
    }
    public class ChooseMonthViewModel : ViewModelBase
    {
        public List<ThangNam> DanhSachThang {  get; set; }
        public ICommand TurnBackCommand { get; set; }
        public ChooseMonthViewModel()
        {
            DanhSachThang = new List<ThangNam>();
            DanhSachThang = GetUniqueThangNam(MainViewModel.listGiaoDich);
            TurnBackCommand = new ViewModelCommand(ExecuteTurnBackCommand);
        }
        private void ExecuteTurnBackCommand(object obj)
        {
            var homeViewModel = ViewModelLocator.Instance.HomeViewModel;
            homeViewModel.MonthChartView = new MonthChartViewModel();
        }
        public List<ThangNam> GetUniqueThangNam(BindingList<GiaoDichModel> listgiaodich)
        {
            HashSet<ThangNam> result = new HashSet<ThangNam>();
            foreach (GiaoDichModel giaodich in listgiaodich)
            {
                result.Add(new ThangNam { Thang = giaodich.NgayTao.Month, Nam = giaodich.NgayTao.Year });
            }
            return result.ToList();
        }
    }
}
