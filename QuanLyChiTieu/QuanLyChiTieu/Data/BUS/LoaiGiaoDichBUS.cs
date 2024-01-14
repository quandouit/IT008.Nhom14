using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QuanLyChiTieu.Data.BUS
{
    public class LoaiGiaoDichBUS
    {
        public static BindingList<LoaiGiaoDichModel> LietKeLoaiGiaoDich()
        {
            BindingList<LoaiGiaoDichModel> result = new BindingList<LoaiGiaoDichModel>();
            var giaoDichData = LoaiGiaoDichDAO.LietKeLoaiGiaoDich();

            for (int i = 0; i < giaoDichData.Rows.Count; i++)
            {
                LoaiGiaoDichModel temp = new LoaiGiaoDichModel
                {
                    TenLoaiGD = giaoDichData.Rows[i]["TENLOAIGD"].ToString(),
                    MaLoaiGD = int.Parse(giaoDichData.Rows[i]["MALOAIGD"].ToString()),
                    TrangThai = giaoDichData.Rows[i]["TRANGTHAI"].ToString()
                };

                result.Add(temp);
            }
            return result;
        }
    }
}
