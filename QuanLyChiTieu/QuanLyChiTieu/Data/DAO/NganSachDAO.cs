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
                sqlCmd.CommandText = "SELECT * FROM NGANSACH WHERE NS.ID = @ID"; ;
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
        public static decimal TienNganSach()
        {
            decimal rt = 0;
            try
            {
                DateTime date = DateTime.Now;
                OpenConn();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "SELECT TIENNS FROM NGANSACH WHERE ID = @ID  AND MONTH(HSD) = @MONTH AND YEAR(HSD) = @YEAR"; ;
                SqlParameter parameterTK = new SqlParameter("@ID", MainViewModel.currentUser.ID);
                sqlCmd.Parameters.Add(parameterTK);
                SqlParameter parameterTK1 = new SqlParameter("@MONTH", date.Month.ToString());
                sqlCmd.Parameters.Add(parameterTK1);
                SqlParameter parameterTK2 = new SqlParameter("@YEAR", date.Year.ToString());
                sqlCmd.Parameters.Add(parameterTK2);
                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read() && !reader.IsDBNull(0))
                    {
                        rt = reader.GetDecimal(0);
                    }
                }
            }

            catch (Exception)
            {
                return -1;
            }
            finally
            {
                CloseConn();
            }
            return rt;
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
