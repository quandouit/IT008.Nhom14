using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View.CustomDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class AddingNewPlanViewModel : ViewModelBase
    {
        public DateTime date {  get; set; }
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public decimal _tienNganSach { get; set; }
        public decimal TienNganSach
        {
            get
            {
                return _tienNganSach;
            }

            set
            {
                _tienNganSach = value;
                OnPropertyChanged(nameof(TienNganSach));
            }
        }

        public List<int> Months { get; } = Enumerable.Range(1, 12).ToList();

        // Danh sách năm
        public List<int> Years { get; } = Enumerable.Range(2000, 2200).ToList();

        private int _selectedMonth;
        public int SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
            }
        }

        private int _selectedYear;
        public int SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }

        NganSachModel NganSachMoi { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public AddingNewPlanViewModel()
        {
            NganSachMoi = new NganSachModel
            {
                ID = MainViewModel.currentUser.ID,
                TienNS = 0,
                HSD = DateTime.Now
            };
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            CloseCommand = new ViewModelCommand(ExecuteCloseCommad);
            LoadHomNay();

        }

        private void LoadHomNay()
        {
            Date = DateTime.Now;
        }

        private void ExecuteCloseCommad(object obj)
        {
            if (obj is Window window)
            {
                YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Thoát ứng dụng", "Bạn có muốn thoát ứng dụng?");
                dialogViewModel.DialogClosed += result =>
                {
                    if (result == DialogResult.OK)
                    {
                        window.Close();
                    }
                };
                YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }

        private void ExecuteAddCommand(object obj)
        {
            NganSachMoi.TienNS = TienNganSach;
            DateTime date = new DateTime();
            date = date.AddDays(30);
            date = date.AddMonths(SelectedMonth);
            date = date.AddYears(SelectedYear);
            NganSachMoi.HSD = date;
            
            NganSachBUS.ThemNganSach(NganSachMoi);
            SharePlanListViewModel.SharedPlanList.Add(NganSachMoi);
        }
    }
}
