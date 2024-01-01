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
    public class SharePlanListViewModel : ViewModelBase
    {
        public BindingList<NganSachModel> SharedPlanListInstance
        {
            get { return SharedPlanList; }
            set
            {
                SharedPlanList = value;
                OnPropertyChanged("SharedPlanListInstance");
            }
        }
        public static BindingList<NganSachModel> SharedPlanList { get; set; }
        public NganSachModel SharedCurrentInstance
        {
            get { return SharedCurrent; }
            set
            {
                SharedCurrent = value;
                OnPropertyChanged("SharedCurrentInstance");
            }
        }
        public static NganSachModel SharedCurrent { get; set; }

        public void LoadAllNganSach()
        {
            SharedPlanListInstance = NganSachBUS.DanhSachNganSach();
        }
        protected void LoadCurrent(DateTime Today)
        {
            SharedCurrentInstance = SharedPlanList.FirstOrDefault(x => x.HSD.Month == Today.Month && x.HSD.Year == Today.Year);
        }
        public static void Reset()
        {
            SharedPlanList = null;
            SharedCurrent = null;
        }
    }
}
