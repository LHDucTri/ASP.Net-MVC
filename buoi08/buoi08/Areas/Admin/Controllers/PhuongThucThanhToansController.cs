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
    public class PhuongThucThanhToansController : Controller
    {
        private Doanltweb3Entities db = new Doanltweb3Entities();

        // GET: Admin/PhuongThucThanhToans
        public ActionResult Index()
        {
            return View(db.PhuongThucThanhToans.ToList());
        }

        // GET: Admin/PhuongThucThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongThucThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhuongThuc,HinhThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.PhuongThucThanhToans.Add(phuongThucThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhuongThuc,HinhThuc")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phuongThucThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhuongThucThanhToan phuongThucThanhToan = db.PhuongThucThanhToans.Find(id);
            db.PhuongThucThanhToans.Remove(phuongThucThanhToan);
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
