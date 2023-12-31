using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChiTieu.Data.DTO
{
    public class LoaiGiaoDichDTO
    {
        public LoaiGiaoDichDTO() { }
        public int MaLoaiGD { get; set; }
        public string TenLoaiGD { get; set; }
        public string TrangThai { get; set; }
        public decimal SumTIEN { get; set; }
    }
}
