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
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.View;
using QuanLyChiTieu.ViewModel;

namespace QuanLyChiTieu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    //biến mainUser lưu trữ thông tin người dùng
    //sử dụng phạm vi toàn chương trình
    //gọi bằng QuanLyChiTieu.SourceClass.mainUser
    public class SourceClass
    {
        public static NguoiDungDTO mainUser;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Text = SourceClass.mainUser.TaiKhoan;
        }
    }
}
