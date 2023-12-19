using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DTO
{
    public class NguoiDungDTO
    {
        public NguoiDungDTO() { }
        public int ID { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Sdt { get; set; }
        public decimal TongTien { get; set; }
    }
}
