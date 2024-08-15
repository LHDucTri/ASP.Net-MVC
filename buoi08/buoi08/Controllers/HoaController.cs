using buoi08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace buoi08.Controllers
{
    public class HoaController : Controller
    {
        public ActionResult SortByName()
        {
            Hoa hoaModel = new Hoa();
            hoaModel.loadHoa();
            hoaModel.SortHoaByName(); // Gọi phương thức sắp xếp theo tên

            return View(hoaModel.danhsach);
        }


        // GET: Hoa/SearchHoa
        public ActionResult SearchHoa(string searchTerm)
        {
            //Hoa hoa = new Hoa();
            Hoa hoaModel = new Hoa();
            hoaModel.loadHoa();

            // Truyền danh sách hoa vào view
            //return View(hoaModel.danhsach);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                hoaModel.SearchHoaByName(searchTerm);
                //return View(hoa.danhsach);
                return View(hoaModel.danhsach);
            }
            else
            {
                // Nếu searchTerm rỗng hoặc null, trả về một danh sách rỗng
                return View(new List<Hoa>());
            }
        }

    }
}