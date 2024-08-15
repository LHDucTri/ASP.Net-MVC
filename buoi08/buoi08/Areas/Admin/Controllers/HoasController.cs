using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using buoi08.Areas.Admin.models;

namespace buoi08.Areas.Admin.Controllers
{
    public class HoasController : Controller
    {
        private Doanltweb3Entities db = new Doanltweb3Entities();

        // GET: Admin/Hoas
        public ActionResult Index()
        {
            var hoas = db.Hoas.Include(h => h.LoaiHoa).Include(h => h.NhaCungCap);
            return View(hoas.ToList());
        }

        // GET: Admin/Hoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            return View(hoa);
        }

        // GET: Admin/Hoas/Create
        public ActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiHoas, "MaLoai", "TenLoai");
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/Hoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoa,TenHoa,GiaBan,MoTa,Anh,SoLuongTon,MaNCC,MaLoai")] Hoa hoa)
        {
            if (ModelState.IsValid)
            {
                db.Hoas.Add(hoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoai = new SelectList(db.LoaiHoas, "MaLoai", "TenLoai", hoa.MaLoai);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoa.MaNCC);
            return View(hoa);
        }

        // GET: Admin/Hoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoai = new SelectList(db.LoaiHoas, "MaLoai", "TenLoai", hoa.MaLoai);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoa.MaNCC);
            return View(hoa);
        }

        // POST: Admin/Hoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoa,TenHoa,GiaBan,MoTa,Anh,SoLuongTon,MaNCC,MaLoai")] Hoa hoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(db.LoaiHoas, "MaLoai", "TenLoai", hoa.MaLoai);
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hoa.MaNCC);
            return View(hoa);
        }

        // GET: Admin/Hoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa hoa = db.Hoas.Find(id);
            if (hoa == null)
            {
                return HttpNotFound();
            }
            return View(hoa);
        }

        // POST: Admin/Hoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoa hoa = db.Hoas.Find(id);
            db.Hoas.Remove(hoa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
