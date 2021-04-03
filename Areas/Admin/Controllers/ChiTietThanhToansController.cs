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
    public class ChiTietThanhToansController : Controller
    {
        private TMDTDAEntities db = new TMDTDAEntities();

        // GET: Admin/ChiTietThanhToans
        public ActionResult Index()
        {
            var chiTietThanhToans = db.ChiTietThanhToans.Include(c => c.DonHangVanChuyen).Include(c => c.ThanhToan);
            return View(chiTietThanhToans.ToList());
        }

        // GET: Admin/ChiTietThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThanhToan chiTietThanhToan = db.ChiTietThanhToans.Find(id);
            if (chiTietThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThanhToan);
        }

        // GET: Admin/ChiTietThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.ShippingID = new SelectList(db.DonHangVanChuyens, "ShippingID", "TinhtrangDH");
            ViewBag.IdTT = new SelectList(db.ThanhToans, "IdTT", "HinhthucTT");
            return View();
        }

        // POST: Admin/ChiTietThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDDH,IdTT,NgayTT,Tongtien,Sdt,ShippingID")] ChiTietThanhToan chiTietThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietThanhToans.Add(chiTietThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShippingID = new SelectList(db.DonHangVanChuyens, "ShippingID", "TinhtrangDH", chiTietThanhToan.ShippingID);
            ViewBag.IdTT = new SelectList(db.ThanhToans, "IdTT", "HinhthucTT", chiTietThanhToan.IdTT);
            return View(chiTietThanhToan);
        }

        // GET: Admin/ChiTietThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThanhToan chiTietThanhToan = db.ChiTietThanhToans.Find(id);
            if (chiTietThanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShippingID = new SelectList(db.DonHangVanChuyens, "ShippingID", "TinhtrangDH", chiTietThanhToan.ShippingID);
            ViewBag.IdTT = new SelectList(db.ThanhToans, "IdTT", "HinhthucTT", chiTietThanhToan.IdTT);
            return View(chiTietThanhToan);
        }

        // POST: Admin/ChiTietThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDDH,IdTT,NgayTT,Tongtien,Sdt,ShippingID")] ChiTietThanhToan chiTietThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShippingID = new SelectList(db.DonHangVanChuyens, "ShippingID", "TinhtrangDH", chiTietThanhToan.ShippingID);
            ViewBag.IdTT = new SelectList(db.ThanhToans, "IdTT", "HinhthucTT", chiTietThanhToan.IdTT);
            return View(chiTietThanhToan);
        }

        // GET: Admin/ChiTietThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietThanhToan chiTietThanhToan = db.ChiTietThanhToans.Find(id);
            if (chiTietThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(chiTietThanhToan);
        }

        // POST: Admin/ChiTietThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietThanhToan chiTietThanhToan = db.ChiTietThanhToans.Find(id);
            db.ChiTietThanhToans.Remove(chiTietThanhToan);
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
