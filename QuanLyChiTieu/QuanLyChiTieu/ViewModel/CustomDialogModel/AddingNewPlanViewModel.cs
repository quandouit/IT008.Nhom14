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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class AddingNewPlanViewModel : ViewModelBase
    {
        public DateTime _date {  get; set; }
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
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
            if (obj is System.Windows.Window window)
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
            DateTime date = new DateTime(SelectedYear,SelectedMonth, 30);
            NganSachMoi.HSD = date;
            if (NganSachMoi.IsFilled())
            {
                if(SharePlanListViewModel.SharedPlanList.Any(item => item.HSD == NganSachMoi.HSD))
                {
                    YesNoDialogViewModel dialogViewModel = new YesNoDialogViewModel("Ngân sách đã tồn tại", "Tháng hiện bạn chọn đã có sẵn một ngân sách, bạn có muốn thay thế?");
                    dialogViewModel.DialogClosed += result =>
                    {
                        if (result == DialogResult.OK)
                        {
                            NganSachBUS.SuaNganSach(NganSachMoi);
                            //var itemsRemove = SharePlanListViewModel.SharedPlanList.Where(item => item.HSD == NganSachMoi.HSD);
                            //foreach(var item in itemsRemove)
                            //{
                            //    SharePlanListViewModel.SharedPlanList.Remove(item);
                            //}
                            //SharePlanListViewModel.SharedPlanList.Add(NganSachMoi);
                            SharePlanListViewModel list = new SharePlanListViewModel();
                            list.LoadAllNganSach();
                        }
                    };
                    YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
                    messageBox.ShowDialog();
                }
                else
                {
                    if(obj is System.Windows.Window window)
                    {
                        NganSachBUS.ThemNganSach(NganSachMoi);
                        SharePlanListViewModel.SharedPlanList.Add(NganSachMoi);
                        window.Close();
                    }    
                }
                
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thiếu thông tin", "Vui lòng điền đầy đủ thông tin giao dịch");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            
        }
    }
}
