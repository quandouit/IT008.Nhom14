using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QuanLyChiTieu
{
    //Lop ke thua viec ket noi database
    public class DBConnection
    {
        protected string strcon = Properties.Settings.Default.stringConn;
        protected SqlConnection sqlCon = null;

        //Ham ket noi csdl
        protected void OpenConn()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strcon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        //Ham dong ket noi csdl
        protected void CloseConn()
        {
            if (sqlCon.State == ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}