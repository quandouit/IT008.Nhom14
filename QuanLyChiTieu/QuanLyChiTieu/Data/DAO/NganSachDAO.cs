using QuanLyChiTieu.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DAO
{
    public class NganSachDAO : DBConnection
    {
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
        public static DataTable TienNganSach()
        {
            try
            {
                OpenConn();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT TIENNS FROM NGANSACH WHERE ID = @ID"; ;
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

        public static DataTable TienDaDung()
        {
            try
            {
                OpenConn();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT SUM(TIEN) as TIENDD FROM NGANSACH AS NS, GIAODICH AS GD WHERE NS.ID = @ID AND MONTH(GD.NGAYTAO) = MONTH(NS.HSD) AND YEAR(GD.NGAYTAO) = YEAR(NS.HSD)"; ;
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
    }
}
