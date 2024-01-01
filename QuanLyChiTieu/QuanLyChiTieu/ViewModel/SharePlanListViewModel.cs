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
        private static BindingList<NganSachModel> _sharedPlanList;
        public static BindingList<NganSachModel> SharedPlanList
        {
            get { return _sharedPlanList; }
            set
            {
                if (_sharedPlanList != value)
                {
                    _sharedPlanList = value;
                    OnSharedPlanListChanged();
                }
            }
        }
        public static event Action SharedPlanListChanged;

        private static void OnSharedPlanListChanged()
        {
            SharedPlanListChanged?.Invoke();
        }

        private static NganSachModel _sharedCurrent;
        public static NganSachModel SharedCurrent
        {
            get { return _sharedCurrent; }
            set
            {
                if (_sharedCurrent != value)
                {
                    _sharedCurrent = value;
                    OnSharedCurrentChanged();
                }
            }
        }

        public static event Action SharedCurrentChanged;

        private static void OnSharedCurrentChanged()
        {
            SharedCurrentChanged?.Invoke();
        }

        protected void LoadAllNganSach()
        {
            SharedPlanList = NganSachBUS.DanhSachNganSach();
        }
    }
}
