using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMDT.Models;

namespace TMDT.Areas.Admin.Controllers
{
    public class CHITIETDONDATHANGsController : Controller
    {
        private TMDTDAEntities db = new TMDTDAEntities();

        // GET: Admin/CHITIETDONDATHANGs
        public ActionResult Index()
        {
            var cHITIETDONDATHANGs = db.CHITIETDONDATHANGs.Include(c => c.DonDatHang).Include(c => c.SanPham);
            return View(cHITIETDONDATHANGs.ToList());
        }

        // GET: Admin/CHITIETDONDATHANGs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONDATHANG cHITIETDONDATHANG = db.CHITIETDONDATHANGs.Find(id);
            if (cHITIETDONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONDATHANG);
        }

        // GET: Admin/CHITIETDONDATHANGs/Create
        public ActionResult Create()
        {
            ViewBag.IdDDH = new SelectList(db.DonDatHangs, "IdDDH", "IdDDH");
            ViewBag.IdSP = new SelectList(db.SanPhams, "IdSP", "TenSP");
            return View();
        }

        // POST: Admin/CHITIETDONDATHANGs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSP,IdDDH,Soluong,Dongia")] CHITIETDONDATHANG cHITIETDONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.CHITIETDONDATHANGs.Add(cHITIETDONDATHANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDDH = new SelectList(db.DonDatHangs, "IdDDH", "IdDDH", cHITIETDONDATHANG.IdDDH);
            ViewBag.IdSP = new SelectList(db.SanPhams, "IdSP", "TenSP", cHITIETDONDATHANG.IdSP);
            return View(cHITIETDONDATHANG);
        }

        // GET: Admin/CHITIETDONDATHANGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONDATHANG cHITIETDONDATHANG = db.CHITIETDONDATHANGs.Find(id);
            if (cHITIETDONDATHANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDDH = new SelectList(db.DonDatHangs, "IdDDH", "IdDDH", cHITIETDONDATHANG.IdDDH);
            ViewBag.IdSP = new SelectList(db.SanPhams, "IdSP", "TenSP", cHITIETDONDATHANG.IdSP);
            return View(cHITIETDONDATHANG);
        }

        // POST: Admin/CHITIETDONDATHANGs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSP,IdDDH,Soluong,Dongia")] CHITIETDONDATHANG cHITIETDONDATHANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHITIETDONDATHANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDDH = new SelectList(db.DonDatHangs, "IdDDH", "IdDDH", cHITIETDONDATHANG.IdDDH);
            ViewBag.IdSP = new SelectList(db.SanPhams, "IdSP", "TenSP", cHITIETDONDATHANG.IdSP);
            return View(cHITIETDONDATHANG);
        }

        // GET: Admin/CHITIETDONDATHANGs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHITIETDONDATHANG cHITIETDONDATHANG = db.CHITIETDONDATHANGs.Find(id);
            if (cHITIETDONDATHANG == null)
            {
                return HttpNotFound();
            }
            return View(cHITIETDONDATHANG);
        }

        // POST: Admin/CHITIETDONDATHANGs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHITIETDONDATHANG cHITIETDONDATHANG = db.CHITIETDONDATHANGs.Find(id);
            db.CHITIETDONDATHANGs.Remove(cHITIETDONDATHANG);
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
