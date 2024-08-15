using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace buoi08.Models
{
    public class ThanhToan
    {
        // Thông tin đơn hàng
        public int MaDonHang { get; set; }
        public DateTime NgayGiao { get; set; }
        public int MaKH { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime NgayLap { get; set; }
        public int MaPhuongThuc { get; set; }
        public decimal TongTien { get; set; }
        // Thông tin người nhận hàng
        public string HoTenNgNhan { get; set; }
        public string GioitinhNgNhan { get; set; }
        public string SDTNgNhan { get; set; }
        public string LoiChuc { get; set; }

        // Thông tin giỏ hàng (Danh sách sản phẩm trong đơn hàng)
        public List<CartItem> CartItems { get; set; }

        // Constructor
        public ThanhToan()
        {
            CartItems = new List<CartItem>();
        }

    }
}