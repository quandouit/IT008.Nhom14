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
using System.Windows.Forms.VisualStyles;

namespace QuanLyChiTieu.Data.BUS
{
    public class NganSachBUS
    {
        public static List<DateTime> HSDNganSach()
        {
            List<DateTime> dateTimes = new List<DateTime>();
            DataTable HSD = NganSachDAO.TatCaNganSach();
            for (int i = 0; i < HSD.Rows.Count; ++i)
            {
                DateTime temp;
                temp = DateTime.Parse(HSD.Rows[i]["HSD"].ToString());
                dateTimes.Add(temp);
            }

            return dateTimes;
        }
        public static decimal TienNganSach()
        {
            return NganSachDAO.TienNganSach();
        }

        public static decimal TienDaDung(decimal tienNganSach)
        {
            var tienDaDung = NganSachDAO.TienDaDung();
            return tienNganSach - decimal.Parse(tienDaDung.Rows[0]["TIENDD"].ToString());
        }
    }
}
