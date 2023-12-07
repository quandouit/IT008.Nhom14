using QuanLyChiTieu.Data.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.BUS
{
    public class GiaoDichBUS
    {
        public static DataTable LietKeGiaoDich()
        {
            return GiaoDichDAO.LietKeGiaoDich();
        }
    }
}
