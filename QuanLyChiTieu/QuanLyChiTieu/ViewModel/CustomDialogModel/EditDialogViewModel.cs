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
    public class EditDialogViewModel : SharePlanListViewModel
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
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                GiaoDichMoi.NgayTao = _selectedDate;
                OnPropertyChanged("SelectedDate");
                LoadTienConLai();
                
            }
        }
        private decimal _soDu;
        public decimal SoDu
        {
            get { return _soDu; }
            set
            {
                _soDu = value;
                OnPropertyChanged(nameof(SoDu));
            }
        }
        private decimal _tienConLai;
        public decimal TienConLai
        {
            get { return _tienConLai; }
            set
            {
                _tienConLai = value;
                OnPropertyChanged(nameof(TienConLai));
            }
        }
        public BindingList<LoaiGiaoDichModel> LoaiGiaoDichData { get; set; }
        public ICommand AutoFillNameCommand { get; set; }
        public ICommand CloseCommand { get; }
        public ICommand AddCommand { get; set; }

        public EditDialogViewModel()
        {

            SoDu = NguoiDungBUS.LaySoDu(MainViewModel.currentUser.ID);
            GiaoDichMoi = new GiaoDichDTO
            {
                ID = MainViewModel.currentUser.ID,
                TenGD = "",
                NgayTao = DateTime.Today,
                GhiChu = "",
                MaLoaiGD = 0
            };
            _isUserInput = false;
            _isAutoFill = false;
            _isEditing = false;
            AutoFillNameCommand = new ViewModelCommand(ExecuteAutoFillNameCommand);
            CloseCommand = new ViewModelCommand(ExecuteCloseCommand);
            AddCommand = new ViewModelCommand(ExecuteAddCommand);
            LoadLoaiGiaoDichData();
            LoadTienConLai();
        }

        private void LoadTienConLai()
        {
            DateTime date = GiaoDichMoi.NgayTao;
            if (SharedPlanList == null)
            {
                LoadAllNganSach();
            }
            LoadCurrent(date);
            decimal TienNS = SharedCurrentInstance.TienNS;
            decimal TienDaDung = NguoiDungBUS.LayTongChi(MainViewModel.currentUser.ID, date.Month, date.Year);
            TienConLai = TienNS - TienDaDung;
        }

        public EditDialogViewModel(GiaoDichModel input)
        {
            SoDu = NguoiDungBUS.LaySoDu(MainViewModel.currentUser.ID);
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
            SelectedDate = DateTime.Today;
            LoadLoaiGiaoDichData();
            LoadTienConLai();
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

        void KhongDuSoDu(bool IsEditing, Window window)
        {
            YesNoDialogViewModel dialogViewModel;
            dialogViewModel = new YesNoDialogViewModel("Không đủ số dư", "Có vẻ số dư của bạn không đủ " +
                                "để thực hiện giao dịch này, bạn có muốn thực hiện?");
            dialogViewModel.DialogClosed += result =>
            {
                if (result == DialogResult.OK)
                {
                    if (IsEditing)
                        GiaoDichBUS.SuaGiaoDich(GiaoDichMoi);
                    else
                        GiaoDichBUS.ThemGiaoDich(GiaoDichMoi);
                    window.Close();
                }
            };
            YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
            messageBox.ShowDialog();
        }

        void KhongDuNganSach(bool IsEditing, Window window)
        {
            YesNoDialogViewModel dialogViewModel;
            dialogViewModel = new YesNoDialogViewModel("Không đủ ngân sách", "Bạn sẽ vượt quá ngân sách tháng nếu thực hiện giao dịch này" +
                ", bạn vẫn muốn tiếp tục?");
            dialogViewModel.DialogClosed += result =>
            {
                if (result == DialogResult.OK)
                {
                    if (IsEditing)
                        GiaoDichBUS.SuaGiaoDich(GiaoDichMoi);
                    else
                        GiaoDichBUS.ThemGiaoDich(GiaoDichMoi);
                    window.Close();
                }
            };
            YesNoDialog messageBox = new YesNoDialog { DataContext = dialogViewModel };
            messageBox.ShowDialog();
        }

        private void ExecuteAddCommand(object obj)
        {
            if (GiaoDichMoi.IsFilled())
            {
                if (obj is Window window)
                {
                    bool flag = true;
                    if (_isEditing)
                    {
                        GiaoDichModel gdHT = MainViewModel.listGiaoDich.FirstOrDefault(x => x.MaGD == GiaoDichMoi.MaGD);
                        if (SoDu + gdHT.Tien - GiaoDichMoi.Tien < 0)
                        {
                            KhongDuSoDu(_isEditing, window);
                        }
                        else if (TienConLai + gdHT.Tien - GiaoDichMoi.Tien < 0)
                        {
                            KhongDuNganSach(_isEditing, window);
                        }
                        else
                        {
                            GiaoDichBUS.SuaGiaoDich(GiaoDichMoi);
                            window.Close();
                        }   
                    }
                    else
                    {
                        if (SoDu - GiaoDichMoi.Tien < 0)
                        {
                            KhongDuSoDu(_isEditing, window);
                        }
                        else if (TienConLai - GiaoDichMoi.Tien < 0)
                        {
                            KhongDuNganSach(_isEditing, window);
                        }
                        else
                        {
                            GiaoDichBUS.ThemGiaoDich(GiaoDichMoi);
                            window.Close();
                        }  
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
