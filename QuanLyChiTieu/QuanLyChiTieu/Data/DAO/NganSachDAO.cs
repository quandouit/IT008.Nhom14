using QuanLyChiTieu.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChiTieu.View.CustomDialog;
using QuanLyChiTieu.ViewModel.CustomDialogModel;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.Model;
using System.Windows.Media;

namespace QuanLyChiTieu.Data.DAO
{
    public class NganSachDAO : DBConnection
    {
        public static DataTable DanhSachNganSach()
        {
            try
            {
                OpenConn();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT * FROM NGANSACH WHERE ID = @ID"; ;
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);
                var reader = sqlCmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
            }

            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }
        public static DataTable TatCaNganSach()
        {
            try
            {
                OpenConn();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT HSD FROM NGANSACH WHERE ID = @ID"; ;
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);
                

                var reader = sqlCmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);
                reader.Close();
                return dt;
            }

            catch (Exception)
            {
                return null;
            }
            finally
            {
                CloseConn();
            }
        }
        public static int ThemNganSach(NganSachModel obj)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "BEGIN TRANSACTION insert into NGANSACH (ID, TIENNS, HSD)\r\nvalues\r\n(@ID , @TIENNS , @HSD) COMMIT;";
                SqlParameter parameter0 = new SqlParameter("@ID", obj.ID);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@TIENNS", obj.TienNS);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@HSD", obj.HSD);
                sqlCmd.Parameters.Add(parameter2);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
        public static int SuaNganSach(NganSachModel ngansach)
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;

                sqlCmd.CommandText = "UPDATE NGANSACH\r\nSET TIENNS = @TIENNS where ID = @ID AND MONTH(HSD) = @MONTH AND YEAR(HSD) = @YEAR";
                SqlParameter parameter0 = new SqlParameter("@TIENNS", ngansach.TienNS);
                sqlCmd.Parameters.Add(parameter0);
                SqlParameter parameter1 = new SqlParameter("@ID", ngansach.ID);
                sqlCmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@MONTH", ngansach.HSD.Month);
                sqlCmd.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@YEAR", ngansach.HSD.Year);
                sqlCmd.Parameters.Add(parameter3);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CustomMessageBoxViewModel dialogViewModel = new CustomMessageBoxViewModel("Lỗi database", ex.Message);
                CustomMessageBox messageBox = new CustomMessageBox { DataContext = dialogViewModel };
                messageBox.ShowDialog();

                return 1;
            }
            finally
            {
                CloseConn();
            }
            return 0;
        }
    }
}
