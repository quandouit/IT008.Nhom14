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
        public string MaGD { get; set; }
        public string ID { get; set; }
        public string MaLoaiGD { get; set; }
        public string TenGD { get; set; }
        public decimal Tien { get; set; }
        public string MinhHoa { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; }

    }
}
