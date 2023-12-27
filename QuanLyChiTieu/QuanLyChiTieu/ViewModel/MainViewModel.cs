using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.View;

namespace QuanLyChiTieu.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public static NguoiDungDTO currentUser { get; set; }
        private ViewModelBase childcurrent;
        private string childcaption;
        private IconChar childicon;
        public ViewModelBase CurrentChildView
        {
            get
            {
                return childcurrent;
            }

            set
            {
                childcurrent = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string ChildCaption
        {
            get
            {
                return childcaption;
            }

            set
            {
                childcaption = value;
                OnPropertyChanged(nameof(ChildCaption));
            }
        }
        public IconChar ChildIcon
        {
            get
            {
                return childicon;
            }

            set
            {
                childicon = value;
                OnPropertyChanged(nameof(ChildIcon));
            }
        }
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowManageViewCommand { get; }
        public ICommand ShowPlanViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        public ICommand MaximizeCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand CloseCommand { get; }

        public MainViewModel(NguoiDungDTO input) 
        {
            currentUser = input;
            if (currentUser.TongTien <= -9999999999)
            {
                InitMoneyViewModel viewModel = new InitMoneyViewModel(currentUser);
                InitMoneyDialog initDialog = new InitMoneyDialog { DataContext = viewModel };
                initDialog.ShowDialog();

                currentUser = NguoiDungDAO.ThongTinNguoiDung(currentUser);
                if (currentUser.ID == 0)
                {
                    MessageBox.Show("Không thể khởi tạo người dùng, vui lòng đăng nhập lại sau");
                    Application.Current.MainWindow.Close();
                }
            }

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowManageViewCommand = new ViewModelCommand(ExecuteShowManageViewCommand);
            ShowPlanViewCommand = new ViewModelCommand(ExecuteShowPlanViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);
            MaximizeCommand = new ViewModelCommand(ExecuteMaximizeCommand);
            MinimizeCommand = new ViewModelCommand(ExecuteMinimizeCommand);
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);

            //default
            ExecuteShowHomeViewCommand(null);
        }
        public MainViewModel() { }

        private void ExecuteCloseCommand(object obj)
        {
            Application.Current.Shutdown();
        }
        private void ExecuteMinimizeCommand(object obj)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ExecuteMaximizeCommand(object obj)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            ChildCaption = "Trang chủ";
            ChildIcon = IconChar.Home;
        }

        private void ExecuteShowManageViewCommand(object obj)
        {
            CurrentChildView = new ManageViewModel();
            ChildCaption = "Quản lý giao dịch";
            ChildIcon = IconChar.SquarePollHorizontal;
        }

        private void ExecuteShowPlanViewCommand(object obj)
        {
            CurrentChildView = new PlanViewModel();
            ChildCaption = "Kế hoạch tài chính";
            ChildIcon = IconChar.Wallet;
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel();
            ChildCaption = "Tài khoản";
            ChildIcon = IconChar.UserAlt;
        }
        
    }
}
