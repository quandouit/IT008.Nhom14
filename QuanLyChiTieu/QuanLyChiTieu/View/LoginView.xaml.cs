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
using System.Windows.Shapes;
using QuanLyChiTieu.Data.BUS;
using QuanLyChiTieu.Data.DTO;
using QuanLyChiTieu.ViewModel;

namespace QuanLyChiTieu.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
           
        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tb_email.Focus();
        }

        private void tb_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_email.Text) && tb_email.Text.Length > 0) 
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void pb_pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(pb_pass.Password) && pb_pass.Password.Length > 0)
            {
                text_pass.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_pass.Visibility = Visibility.Visible;
            }
        }

        private void text_pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pb_pass.Focus();
        }

        private void bt_signin_Click(object sender, RoutedEventArgs e)
        {
            //Tạo thông tin người dùng đăng nhập
            NguoiDungDTO user = new NguoiDungDTO();
            user.TaiKhoan = tb_email.Text;
            user.MatKhau = pb_pass.Password;

            //Tạo thông tin trả về khi kiểm tra người dùng có tồn tại hay không
            NguoiDungDTO userLogin = LoginBUS.Try_Login(user);
            QuanLyChiTieu.SourceClass.mainUser = userLogin;

            if (userLogin.ID != 0) 
            {
                Application.Current.MainWindow = new MainWindow();
                Application.Current.MainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ten dang nhap hoac mat khau khong dung!");
                pb_pass.Password = "";
                text_pass.Visibility = Visibility.Visible;
            }
        }
    }
}
