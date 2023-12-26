using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
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
            var giaoDichData = GiaoDichDAO.LietKeGiaoDich();

            for (int i = 0; i < giaoDichData.Rows.Count; i++)
            {
                GiaoDichModel temp = new GiaoDichModel();
                temp.STT = int.Parse(giaoDichData.Rows[i]["STT"].ToString());
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
        public static void ThemGiaoDich(GiaoDichDTO obj)
        {
            if (GiaoDichDAO.ThemGiaoDich(obj) == 0)
                MessageBox.Show("Thêm mới giao dịch thành công!");
            else
                MessageBox.Show("Thêm mới giao dịch thất bại!");
        }
        public static void XoaGiaoDich(int MAGD)
        {
            if (GiaoDichDAO.XoaGiaoDich(MAGD) == 0)
                MessageBox.Show("Xóa giao dịch thành công!");
            else
                MessageBox.Show("Xóa giao dịch thất bại!");
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
                MessageBox.Show("Hoàn thành xóa các giao dịch được chọn!");
            }
            else
            {
                MessageBox.Show("Chưa hoàn thành xóa các giao dịch được chọn!");
            }
        }
        public static void SuaGiaoDich(GiaoDichDTO obj)
        {
            if (GiaoDichDAO.SuaGiaoDich(obj) == 0)
                MessageBox.Show("Sửa đổi thông tin giao dịch thành công!");
            else
                MessageBox.Show("Sửa đổi thông tin giao dịch thất bại!");
        }
    }
}
