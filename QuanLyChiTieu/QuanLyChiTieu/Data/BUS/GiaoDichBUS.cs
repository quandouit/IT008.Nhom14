using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Data.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu.Data.BUS
{
    public class GiaoDichBUS
    {
        public static DataTable LietKeGiaoDich()
        {
            var giaoDichData = GiaoDichDAO.LietKeGiaoDich();
            if (giaoDichData == null)
            {
                return null;
            }

            IEnumerable<DataRow> giaoDichDataEnumerable = giaoDichData.AsEnumerable();

            var sortedRows = giaoDichDataEnumerable
                .Where(gd => gd["NGAYTAO"] != DBNull.Value)
                .OrderByDescending(gd => Convert.ToDateTime(gd["NGAYTAO"]))
                .ToList();

            DataTable sortedTable = sortedRows.CopyToDataTable();

            return sortedTable;
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
        public static void HienThiChiTietGiaoDich(object obj)
        {
            GiaoDichDAO.HienThiChiTietGiaoDich(obj);
        }
    }
}
