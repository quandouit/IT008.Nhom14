using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace QuanLyChiTieu
{
    //Lop ke thua viec ket noi database
    public class DBConnection
    {
        //protected static string strcon = Properties.Settings.Default.stringConn;
        protected static string strcon = "Server=tcp:sonn.database.windows.net,1433;Initial Catalog=QLTC;Persist Security Info=False;User ID=sonn;Password=Son@2004;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected static SqlConnection sqlCon = null;

        //Ham ket noi csdl
        protected static void OpenConn()
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
        protected static void CloseConn()
        {
            if (sqlCon.State == ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }
    }
}
