using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Markup.Localizer;

namespace QuanLyChiTieu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Test : DBConnection
    {
        //Ke thua va bo sung them phuong thuc truy xuat ra man hinh
        public void ThongBao()
        {
            OpenConn();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from User_info";
            sqlCmd.Connection = sqlCon;

            string data = "";
            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ID = reader.GetString(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                string phone = reader.GetString(3);
                SqlMoney balance = reader.GetSqlMoney(4);
                
                data = data + " " + ID + " " + username + " " + " " + password + " " + phone;
                data = data + " " + balance.ToString(); 
                data = data + "\n";
            }
            reader.Close();
            MessageBox.Show(data);
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //Ket noi thu database
            Test test = new Test();
            test.ThongBao();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage (IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void winCtrBar_LButtonDown(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void winCtrBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private void winClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void winMax_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void winMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
