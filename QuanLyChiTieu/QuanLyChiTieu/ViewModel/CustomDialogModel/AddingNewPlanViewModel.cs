using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class AddingNewPlanViewModel : ViewModelBase
    {
        NganSachDTO NganSachMoi { get; set; }

        public ICommand AddCommand { get; set; }
        public AddingNewPlanViewModel()
        {
            NganSachMoi = new NganSachDTO
            {
                ID = MainViewModel.currentUser.ID,
                TienNS = 0,
                HSD = DateTime.Now
            };
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
        }

        private void ExecuteAddCommand(object obj)
        {
            MessageBox.Show("Da them thanh cong");
        }
    }
}
