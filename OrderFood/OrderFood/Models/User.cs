using System;
using System.Collections.Generic;
using System.Text;

namespace OrderFood.Models
{
    public class User
    {
        public int MaKH { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int Tuoi { get; set; }
        public string Sdt { get; set; }
        public bool GioiTinh { get; set; }
    }
}
