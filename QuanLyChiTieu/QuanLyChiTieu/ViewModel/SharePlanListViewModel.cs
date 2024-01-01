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
        public BindingList<NganSachModel> SharedCurrentInstance
        {
            get { return SharedCurrent; }
            set
            {
                SharedCurrent = value;
                OnPropertyChanged("SharedCurrentInstance");
            }
        }

        public static BindingList<NganSachModel> SharedCurrent { get; set; }

        protected void LoadAllNganSach()
        {
            SharedPlanList = NganSachBUS.DanhSachNganSach();
        }
    }
}
