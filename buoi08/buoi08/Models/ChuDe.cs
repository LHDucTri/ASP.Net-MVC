using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace buoi08.Models
{
    public class ChuDe
    {
        public int maloai { get; set; }
        public string tenloai { get; set; }
      
        public List<ChuDe> danhsach;
        public void loadChuDe()
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ketnoi1"].ConnectionString;
            //string connStr = @"Server=MSI\SQLEXPRESS; Database= DataSQL;User ID=sa; Password=123; Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from LoaiHoa", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            danhsach = new List<ChuDe>();
            while (dr.Read())
            {
                danhsach.Add(new ChuDe { maloai = Convert.ToInt32(dr.GetValue(0)), tenloai = dr.GetValue(1).ToString() });
            }
            dr.Close();
        }
    }
}