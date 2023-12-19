using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DAO
{
    public class GiaoDichDAO : DBConnection
    {
        public static DataTable LietKeGiaoDich()
        {
            try
            {
                OpenConn();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "select * from GIAODICH where ID = @ID";

                SqlParameter parameterID = new SqlParameter("@ID", QuanLyChiTieu.SourceClass.mainUser.ID);
                sqlCmd.Parameters.Add(parameterID);
                

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
