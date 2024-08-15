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
    public class LienHesController : Controller
    {
        private Doanltweb3Entities db = new Doanltweb3Entities();

        // GET: Admin/LienHes
        public ActionResult Index()
        {
            var lienHes = db.LienHes.Include(l => l.KhachHang);
            return View(lienHes.ToList());
        }

        // GET: Admin/LienHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienHe = db.LienHes.Find(id);
            if (lienHe == null)
            {
                return HttpNotFound();
            }
            return View(lienHe);
        }

        // GET: Admin/LienHes/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen");
            return View();
        }

        // POST: Admin/LienHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLienHe,Ten,Gmail,TinNhan,MaKH")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                db.LienHes.Add(lienHe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", lienHe.MaKH);
            return View(lienHe);
        }

        // GET: Admin/LienHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienHe = db.LienHes.Find(id);
            if (lienHe == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", lienHe.MaKH);
            return View(lienHe);
        }

        // POST: Admin/LienHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLienHe,Ten,Gmail,TinNhan,MaKH")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lienHe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoTen", lienHe.MaKH);
            return View(lienHe);
        }

        // GET: Admin/LienHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LienHe lienHe = db.LienHes.Find(id);
            if (lienHe == null)
            {
                return HttpNotFound();
            }
            return View(lienHe);
        }

        // POST: Admin/LienHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LienHe lienHe = db.LienHes.Find(id);
            db.LienHes.Remove(lienHe);
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
