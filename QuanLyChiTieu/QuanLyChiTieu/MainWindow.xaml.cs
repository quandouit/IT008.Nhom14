﻿using System;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
