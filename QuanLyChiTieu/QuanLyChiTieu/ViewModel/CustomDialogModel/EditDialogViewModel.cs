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
using QuanLyChiTieu.View.CustomDialog;
using System.Windows.Forms;

namespace QuanLyChiTieu.ViewModel.CustomDialogModel
{
    public class EditDialogViewModel : ViewModelBase
    {
        public static bool _isUserInput;
        public static bool _isAutoFill;
        private bool _isEditing;
        public GiaoDichDTO GiaoDichMoi { get; set; }
        private LoaiGiaoDichModel _selectedLoaiGD;
        public LoaiGiaoDichModel SelectedLoaiGD
        {
            get { return _selectedLoaiGD; }
            set
            {
                if (_selectedLoaiGD != value)
                {
                    _selectedLoaiGD = value;
                    GiaoDichMoi.MaLoaiGD = _selectedLoaiGD.MaLoaiGD;
                    OnPropertyChanged("SelectedLoaiGD");
                    if (!_isUserInput)
                    {
                        ExecuteAutoFillNameCommand(null);
                    }
                }
            }
        }
        public BindingList<LoaiGiaoDichModel> LoaiGiaoDichData { get; set; }
        public ICommand AutoFillNameCommand { get; set; }
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public EditDialogViewModel()
        {
            GiaoDichMoi = new GiaoDichDTO
            {
                ID = MainViewModel.currentUser.ID,
                TenGD = "",
                NgayTao = DateTime.Today,
                GhiChu = ""
            };
            _isUserInput = false;
            _isAutoFill = false;
            _isEditing = false;
            AutoFillNameCommand = new ViewModelCommand(ExecuteAutoFillNameCommand);
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            LoadLoaiGiaoDichData();
        }
        public EditDialogViewModel(GiaoDichModel input)
        {
            GiaoDichMoi = new GiaoDichDTO
            {
                MaGD = input.MaGD,
                TenGD = input.TenGD,
                MaLoaiGD = input.MaLoaiGD,
                Tien = input.Tien,
                NgayTao = input.NgayTao,
                GhiChu = input.GhiChu
            };
            _isUserInput = true;
            _isAutoFill = false;
            _isEditing = true;
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            LoadLoaiGiaoDichData();

            SelectedLoaiGD = LoaiGiaoDichData.FirstOrDefault(x => x.MaLoaiGD == GiaoDichMoi.MaLoaiGD);
        }

        public void LoadLoaiGiaoDichData()
        {
            LoaiGiaoDichData = LoaiGiaoDichBUS.LietKeLoaiGiaoDich();
        }
        private void ExecuteAutoFillNameCommand(object obj)
        {
            if (!_isUserInput && !_isEditing)
            {
                _isAutoFill = true;
                GiaoDichMoi.TenGD = SelectedLoaiGD.TenLoaiGD;
                _isAutoFill = false;
            }
        }
        private void ExecuteCloseCommand(object obj)
        {
            if (obj is Window window)
            {
                YesNoDialogViewModel dialogViewModel;
                if (_isEditing)
                {
                    dialogViewModel = new YesNoDialogViewModel("Dừng chỉnh sửa", "Bạn có muốn dừng chỉnh sửa giao dịch không?");
                }
                else
                {
                    dialogViewModel = new YesNoDialogViewModel("Dừng thêm mới", "Bạn có muốn dừng tạo giao dịch mới không?");
                }

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
            if (obj is Window window)
            {
                if (_isEditing)
                {
                    GiaoDichBUS.SuaGiaoDich(GiaoDichMoi);
                }
                else
                {
                    GiaoDichBUS.ThemGiaoDich(GiaoDichMoi);
                }
                window.Close();
            }
        }
    }
}