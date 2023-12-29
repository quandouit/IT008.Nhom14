using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.BUS
{
    public class GiaoDichBUS
    {
        public static BindingList<GiaoDichModel> LietKeGiaoDich()
        {
            BindingList<GiaoDichModel> result = new BindingList<GiaoDichModel>();
            DataTable giaoDichData = GiaoDichDAO.LietKeGiaoDich();

            for (int i = 0; i < giaoDichData.Rows.Count; i++)
            {
                GiaoDichModel temp = new GiaoDichModel();
                temp.STT = 0;
                temp.MaGD = int.Parse(giaoDichData.Rows[i]["MAGD"].ToString());
                temp.MaLoaiGD = int.Parse(giaoDichData.Rows[i]["MALOAIGD"].ToString());
                temp.ID = int.Parse(giaoDichData.Rows[i]["ID"].ToString());
                temp.TenLoaiGD = giaoDichData.Rows[i]["TENLOAIGD"].ToString();
                temp.Tien = decimal.Parse(giaoDichData.Rows[i]["TIEN"].ToString());
                temp.TrangThai = giaoDichData.Rows[i]["TRANGTHAI"].ToString();
                temp.TenGD = giaoDichData.Rows[i]["TENGD"].ToString();
                temp.GhiChu = giaoDichData.Rows[i]["GHICHU"].ToString();
                temp.NgayTao = DateTime.Parse(giaoDichData.Rows[i]["NGAYTAO"].ToString());
                temp.IsChecked = false;

                result.Add(temp);
            }
            return result;
        }
        public static BindingList<GiaoDichModel> SapXepGiaoDich(BindingList<GiaoDichModel> input)
        {
            List<GiaoDichModel> sortedList = input.OrderByDescending(gd => gd.NgayTao).ToList();
            for (int i = 0; i < sortedList.Count; i++)
            {
                sortedList[i].STT = i + 1;
            };
            BindingList<GiaoDichModel> output = new BindingList<GiaoDichModel>(sortedList);
            return output;
        }
        public static void ThemGiaoDich(GiaoDichDTO obj)
        {
            if (GiaoDichDAO.ThemGiaoDich(obj) == 0)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thành công", "Thêm mới giao dịch thành công!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Thêm mới giao dịch thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
        public static void XoaGiaoDich(int MAGD)
        {
            if (GiaoDichDAO.XoaGiaoDich(MAGD) == 0)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thành công", "Xóa giao dịch thành công!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Xóa giao dịch thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
        public static void XoaNhieuGiaoDich(BindingList<GiaoDichModel> GiaoDichData)
        {
            bool success = true;
            foreach (GiaoDichModel row in GiaoDichData)
            {
                if (row.IsChecked == true)
                {
                    if (GiaoDichDAO.XoaGiaoDich(row.MaGD) != 0)
                    {
                        success = false;
                    }
                }
            }
            if (success)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Hoàn thành", "Hoàn thành xóa các giao dịch được chọn!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Chưa hoàn thành", "Chưa hoàn thành xóa các giao dịch được chọn!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
        public static void SuaGiaoDich(GiaoDichDTO obj)
        {
            if (GiaoDichDAO.SuaGiaoDich(obj) == 0)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thành công", "Sửa đổi thông tin giao dịch thành công!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Sửa đổi thông tin giao dịch thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
        }
    }
}
