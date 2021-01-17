using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFood.Models
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayHD { get; set; }
        public bool TrangThai { get; set; }
        public decimal TongTien { get; set; }
    }
}
