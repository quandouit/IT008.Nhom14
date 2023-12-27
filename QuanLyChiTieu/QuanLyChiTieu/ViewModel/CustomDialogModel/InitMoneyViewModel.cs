using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using QuanLyChiTieu.Data.BUS;
using System.Data;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.Data.DTO;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class InitMoneyViewModel : ViewModelBase
    {
        public NguoiDungDTO User { get; set; }
        private decimal _money;
        public string Money
        {
            get
            {
                return (_money).ToString();
            }

            set
            {
                _money = Decimal.Parse(value);
                OnPropertyChanged("Money");
            }
        }
        public ICommand ConfirmCommand { get; }
        public InitMoneyViewModel(NguoiDungDTO input) 
        {
            User = input;
            ConfirmCommand = new ViewModelCommand(ExecuteConfirmCommand);
        }
        public InitMoneyViewModel() { }
        private void ExecuteConfirmCommand(object obj)
        {
            if (!string.IsNullOrWhiteSpace(Money))
            {
                if (NguoiDungBUS.DoiSotien(User, _money))
                {
                    if (obj is Window window)
                    {
                        window.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số dư để khởi tạo tài khoản");
            }
        }
    }
}
