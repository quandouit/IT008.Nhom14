using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace QuanLyChiTieu.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
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
        public ICommand ShowHistoryViewCommand { get; }
        public ICommand ShowTransactionViewCommand { get; }
        public ICommand ShowPlanViewCommand { get; }
        public ICommand ShowGoalViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }
        
        public MainViewModel() 
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowHistoryViewCommand = new ViewModelCommand(ExecuteShowHistoryViewCommand);
            ShowTransactionViewCommand = new ViewModelCommand(ExecuteShowTransactionViewCommand);
            ShowPlanViewCommand = new ViewModelCommand(ExecuteShowPlanViewCommand);
            ShowGoalViewCommand = new ViewModelCommand(ExecuteShowGoalViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            //default
            ExecuteShowHomeViewCommand(null);
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            ChildCaption = "Trang chủ";
            ChildIcon = IconChar.Home;
        }

        private void ExecuteShowHistoryViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel();
            ChildCaption = "Lịch sử giao dịch";
            ChildIcon = IconChar.SquarePollHorizontal;
        }

        private void ExecuteShowTransactionViewCommand(object obj)
        {
            CurrentChildView = new TransactionViewModel();
            ChildCaption = "Tạo giao dịch mới";
            ChildIcon = IconChar.CartPlus;
        }

        private void ExecuteShowPlanViewCommand(object obj)
        {
            CurrentChildView = new PlanViewModel();
            ChildCaption = "Kế hoạch tài chính";
            ChildIcon = IconChar.Wallet;
        }

        private void ExecuteShowGoalViewCommand(object obj)
        {
            CurrentChildView = new GoalViewModel();
            ChildCaption = "Mục tiêu tiết kiệm";
            ChildIcon = IconChar.Coins;
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            CurrentChildView = new UserViewModel();
            ChildCaption = "Tài khoản";
            ChildIcon = IconChar.UserAlt;
        }
    }
}
