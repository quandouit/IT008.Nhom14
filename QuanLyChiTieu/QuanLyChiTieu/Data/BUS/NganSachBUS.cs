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
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;

namespace QuanLyChiTieu.Data.BUS
{
    public class NganSachBUS
    {
        public static BindingList<NganSachModel> DanhSachNganSach()
        {
            BindingList<NganSachModel> result = new BindingList<NganSachModel>();
            DataTable danhSach = NganSachDAO.DanhSachNganSach();

            for (int i = 0; i < danhSach.Rows.Count; i++)
            {
                NganSachModel temp = new NganSachModel();
                temp.ID = int.Parse(danhSach.Rows[i]["ID"].ToString());
                temp.TienNS = decimal.Parse(danhSach.Rows[i]["TIENNS"].ToString());
                temp.HSD = DateTime.Parse(danhSach.Rows[i]["HSD"].ToString());
                result.Add(temp);
            }
            return result;
        }

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
        public static decimal TienNganSach(DateTime date)
        {
            return NganSachDAO.TienNganSach(date);
        }

        public static decimal TienDaDung(decimal tienNganSach)
        {
            var tienDaDung = NganSachDAO.TienDaDung();
            return tienNganSach - decimal.Parse(tienDaDung.Rows[0]["TIENDD"].ToString());
        }

        public static void ThemNganSach(NganSachModel nganSachMoi)
        {
            if(NganSachDAO.ThemNganSach(nganSachMoi) == 0)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thành công", "Thêm mới ngân sách thành công!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }
            else
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Thất bại", "Thêm mới ngân sách thất bại!");
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();
            }    
        }
    }
}
