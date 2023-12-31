using QuanLyChiTieu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Helper
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _instance;
        public static ViewModelLocator Instance => _instance ?? (_instance = new ViewModelLocator());

        public MainViewModel MainViewModel { get; set; }
    }
}
