using QuanLyChiTieu.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QuanLyChiTieu
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //LoginView loginView = new LoginView();
            //loginView.Show();
            MainWindow = new MainWindow();
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
