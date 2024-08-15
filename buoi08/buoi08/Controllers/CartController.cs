using buoi08.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi08.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSessionKey = "Cart";
        public ActionResult Index()
        {
            var cart = GetCart(); // Giả sử bạn có phương thức để lấy giỏ hàng hiện tại
            return View(cart.Items); // Giả sử Items là danh sách các mặt hàng trong giỏ hàng
        }
        // GET: Cart
       

 [HttpPost]
[ValidateAntiForgeryToken]
        public ActionResult AddToCart(int id, int quantity)
        {
            var cart = GetCart();
            var flower = GetFlowerById(id);

            if (flower != null)
            {
                var cartItem = new CartItem
                {
                    ProductId = flower.mahoa,
                    ProductName = flower.tenhoa,
                    Price = flower.giaban,
                    Quantity = quantity
                };

                cart.AddItem(cartItem);
                SaveCart(cart);
            }

            return RedirectToAction("Cart");
        }

        public ActionResult Cart()
        {
            var cart = GetCart();
            return View(cart);
        }

        private Cart GetCart()
        {
            var cart = Session[CartSessionKey] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            Session[CartSessionKey] = cart;
        }

        private Hoa GetFlowerById(int id)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ketnoi1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT MaHoa, TenHoa, GiaBan, Anh, Mota, MaLoai FROM Hoa WHERE MaHoa = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            Hoa flower = null;
            if (dr.Read())
            {
                flower = new Hoa
                {
                    mahoa = Convert.ToInt32(dr.GetValue(0)),
                    tenhoa = dr.GetValue(1).ToString(),
                    giaban = Convert.ToDecimal(dr.GetValue(2)),
                    anhbia = dr.GetValue(3).ToString(),
                    mota = dr.GetValue(4).ToString(),
                    maloai = Convert.ToInt32(dr.GetValue(5))
                };
            }
            dr.Close();
            conn.Close();
            return flower;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = GetCart(); // Lấy giỏ hàng hiện tại
            cart.RemoveItem(id); // Xóa sản phẩm khỏi giỏ hàng
            SaveCart(cart); // Lưu giỏ hàng đã cập nhật

            return RedirectToAction("Index"); // Chuyển hướng về trang giỏ hàng
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThanhToan(bool payment)
        {
            var cart = GetCart();
            if (cart.Items.Count == 0)
            {
                return RedirectToAction("Index");
            }

            // Tạo mô hình ThanhToanViewModel và truyền dữ liệu từ giỏ hàng
            var model = new ThanhToanViewModel
            {
                CartItems = cart.Items,
                TongTien = cart.GetTotal(),
                NgayGiao = DateTime.Now, // Hoặc lấy từ form nếu bạn muốn
                MaPhuongThuc = 1, // Phương thức thanh toán, có thể lấy từ form
                HoTenNgNhan = "", // Điền thông tin từ form
                GioitinhNgNhan = "", // Điền thông tin từ form
                SDTNgNhan = "", // Điền thông tin từ form
                LoiChuc = "" // Điền thông tin từ form
            };

            // Xóa giỏ hàng sau khi thanh toán
            Session[CartSessionKey] = null;

            // Chuyển hướng đến trang thanh toán
            return View("ThanhToan", model);
        }
    }
}