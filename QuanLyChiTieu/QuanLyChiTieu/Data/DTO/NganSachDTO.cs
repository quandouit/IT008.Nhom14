using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DTO
{
    public class NganSachDTO
    {
        public NganSachDTO() { }
        public string MaNS { get; set; }
        public string ID {  get; set; }
        public string TenNS { get; set; }
        public decimal TienNS { get; set; }
        public DateTime HSD { get; set; }
    }
}
