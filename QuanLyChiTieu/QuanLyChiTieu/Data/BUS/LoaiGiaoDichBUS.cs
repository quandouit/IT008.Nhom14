using QuanLyChiTieu.Data.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.BUS
{
    public class LoaiGiaoDichBUS
    {
        public static DataTable LietKeLoaiGiaoDich()
        {
            return LoaiGiaoDichDAO.LietKeLoaiGiaoDich();
        }
    }
}
