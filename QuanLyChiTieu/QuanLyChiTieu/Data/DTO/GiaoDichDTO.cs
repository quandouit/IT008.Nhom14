using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DTO
{
    public class GiaoDichDTO
    {
        public GiaoDichDTO() { }
        public int MaGD { get; set; }
        public int ID { get; set; }
        public int MaLoaiGD { get; set; }
        public string TenGD { get; set; }
        public decimal Tien { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
