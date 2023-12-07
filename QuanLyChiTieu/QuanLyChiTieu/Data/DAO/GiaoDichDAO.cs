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
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                }

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from GIAODICH";
                sqlCmd.Connection = sqlCon;

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
                sqlCon.Close();
            }
        }
    }
}
