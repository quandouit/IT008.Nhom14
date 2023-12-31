using QuanLyChiTieu.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.Data.DAO;
using QuanLyChiTieu.Model;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace QuanLyChiTieu.Data.BUS
{
    public class NganSachBUS
    {
        public static decimal TienNganSach()
        {
            var tienNganSach = NganSachDAO.TienNganSach();
            return decimal.Parse(tienNganSach.Rows[0]["TIENNS"].ToString());
        }

        public static decimal TienDaDung(decimal tienNganSach)
        {
            var tienDaDung = NganSachDAO.TienDaDung();
            return tienNganSach - decimal.Parse(tienDaDung.Rows[0]["TIENDD"].ToString());
        }
    }
}
