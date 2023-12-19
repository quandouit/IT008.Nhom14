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
    }


}
