using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buoi08.Models
{
    public class ThanhToanViewModel
    {
        public DateTime NgayGiao { get; set; }
        public string HoTenNgNhan { get; set; }
        public string GioitinhNgNhan { get; set; }
        public string SDTNgNhan { get; set; }
        public string LoiChuc { get; set; }
        public int MaPhuongThuc { get; set; } // 1: Tiền mặt, 2: Online
        public decimal TongTien { get; set; }
        public List<CartItem> CartItems { get; set; }

        
    }
}