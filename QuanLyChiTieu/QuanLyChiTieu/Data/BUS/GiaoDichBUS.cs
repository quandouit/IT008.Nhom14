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

            for (int i=0; i < giaoDichData.Rows.Count; i++)
            {
                GiaoDichModel temp = new GiaoDichModel();
                temp.STT = int.Parse(giaoDichData.Rows[i]["STT"].ToString());
                temp.MaGD = int.Parse(giaoDichData.Rows[i]["MAGD"].ToString());
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
                MessageBox.Show("Them moi giao dich thanh cong!");
            else
                MessageBox.Show("Them moi giao dich that bai!");
        }
        public static void XoaGiaoDich(object MAGD)
        {
            if (GiaoDichDAO.XoaGiaoDich(MAGD) == 0)
                MessageBox.Show("Xoa giao dich thanh cong!");
            else
                MessageBox.Show("Xoa giao dich that bai!");
        }
    }
}
