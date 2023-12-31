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
        private BindingList<NganSachModel> _sharedPlanList;
        public BindingList<NganSachModel> SharedPlanList
        {
            get { return _sharedPlanList; }
            set
            {
                _sharedPlanList = value;
                OnPropertyChanged("SharedPlanList");
            }
        }
        private NganSachModel _sharedCurrent;
        public NganSachModel SharedCurrent
        {
            get { return _sharedCurrent; }
            set
            {
                _sharedCurrent = value;
                OnPropertyChanged("SharedCurrent");
            }
        }
    }
}
