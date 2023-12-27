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

namespace QuanLyChiTieu.Data.BUS
{
    public class NganSachBUS
    {
        public static string TienNganSach()
        {
            string result;
            var tienNganSach = NganSachDAO.TienNganSach();
            result = tienNganSach.Rows[0]["TIENNS"].ToString();
            return result;
        }

        public static string TienDaDung()
        {
            string result;
            var tienNganSach = NganSachDAO.TienNganSach();
            var tienDaDung = NganSachDAO.TienDaDung();
            var tienConLai = decimal.Parse(tienNganSach.Rows[0]["TIENNS"].ToString()) - decimal.Parse(tienDaDung.Rows[0]["TIENDD"].ToString());
            result = tienConLai.ToString();
            return result;
        }
    }
}
