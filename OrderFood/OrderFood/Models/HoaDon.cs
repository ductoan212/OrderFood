using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFood.Models
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public string MaKH { get; set; }
        public DateTime NgayHD { get; set; }
        public int TrangThai { get; set; }
        public decimal TongTien { get; set; }
    }
}
