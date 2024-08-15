using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace buoi08.Models
{
    public class Hoa
    {
        public int mahoa { get; set; }
        public string tenhoa { get; set; }
        public decimal giaban { get; set; }
        public string anhbia { get; set; }
        public string mota { get; set; }
        public int maloai { get; set; }

        public List<Hoa> danhsach;

        public void loadHoa()
        {
            // string connStr = @"Server=MSI\SQLEXPRESS; Database= DataSQL;User ID=sa; Password=123; Integrated Security=True;";
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ketnoi1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MaHoa, TenHoa, GiaBan, Anh, Mota, MaLoai from Hoa", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            danhsach = new List<Hoa>();
            while (dr.Read())
            {
                danhsach.Add(new Hoa { mahoa = Convert.ToInt32(dr.GetValue(0)), tenhoa = dr.GetValue(1).ToString(), giaban = Convert.ToDecimal(dr.GetValue(2)), anhbia = dr.GetValue(3).ToString(), mota = dr.GetValue(4).ToString(), maloai = Convert.ToInt32(dr.GetValue(5)) });
            }
            dr.Close();
        }

        public void loadHoa2(string machude)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ketnoi1"].ConnectionString;
            //string connStr = @"Server=MSI\SQLEXPRESS; Database= DataSQL;User ID=sa; Password=123; Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MaHoa, TenHoa, GiaBan, Anhbia, Mota, MaLoai from Hoa where MaLoai= @id", conn);
            cmd.Parameters.AddWithValue("@id", machude);
            SqlDataReader dr = cmd.ExecuteReader();
            danhsach = new List<Hoa>();
            while (dr.Read())
            {
                danhsach.Add(new Hoa { mahoa = Convert.ToInt32(dr.GetValue(0)), tenhoa = dr.GetValue(1).ToString(), giaban = Convert.ToDecimal(dr.GetValue(2)), anhbia = dr.GetValue(3).ToString(), mota = dr.GetValue(4).ToString(), maloai = Convert.ToInt32(dr.GetValue(5)) });
            }
            dr.Close();
        }

        // New method to search flowers by name
        public void SearchHoaByName(string tenHoa)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ketnoi1"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select MaHoa, TenHoa, GiaBan, Anh, Mota, MaLoai from Hoa where TenHoa like @tenHoa", conn);
            cmd.Parameters.AddWithValue("@tenHoa", "%" + tenHoa + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            danhsach = new List<Hoa>();
            while (dr.Read())   
            {
                danhsach.Add(new Hoa { mahoa = Convert.ToInt32(dr.GetValue(0)), tenhoa = dr.GetValue(1).ToString(), giaban = Convert.ToDecimal(dr.GetValue(2)), anhbia = dr.GetValue(3).ToString(), mota = dr.GetValue(4).ToString(), maloai = Convert.ToInt32(dr.GetValue(5)) });
            }
            dr.Close();
            
        }
        public void SortHoaByName()
        {
            if (danhsach != null && danhsach.Count > 0)
            {
                danhsach = danhsach.OrderBy(h => h.tenhoa).ToList();
            }
        }

    }
}
