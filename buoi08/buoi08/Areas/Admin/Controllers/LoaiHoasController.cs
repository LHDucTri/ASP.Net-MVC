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
    public class LoaiHoasController : Controller
    {
        private Doanltweb3Entities db = new Doanltweb3Entities();

        // GET: Admin/LoaiHoas
        public ActionResult Index()
        {
            return View(db.LoaiHoas.ToList());
        }

        // GET: Admin/LoaiHoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHoa loaiHoa = db.LoaiHoas.Find(id);
            if (loaiHoa == null)
            {
                return HttpNotFound();
            }
            return View(loaiHoa);
        }

        // GET: Admin/LoaiHoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoai,MaNCC,SoLuong")] LoaiHoa loaiHoa)
        {
            if (ModelState.IsValid)
            {
                db.LoaiHoas.Add(loaiHoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiHoa);
        }

        // GET: Admin/LoaiHoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHoa loaiHoa = db.LoaiHoas.Find(id);
            if (loaiHoa == null)
            {
                return HttpNotFound();
            }
            return View(loaiHoa);
        }

        // POST: Admin/LoaiHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoai,MaNCC,SoLuong")] LoaiHoa loaiHoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiHoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiHoa);
        }

        // GET: Admin/LoaiHoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiHoa loaiHoa = db.LoaiHoas.Find(id);
            if (loaiHoa == null)
            {
                return HttpNotFound();
            }
            return View(loaiHoa);
        }

        // POST: Admin/LoaiHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiHoa loaiHoa = db.LoaiHoas.Find(id);
            db.LoaiHoas.Remove(loaiHoa);
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
