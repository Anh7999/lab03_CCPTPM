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
    public class DonHangVanChuyensController : Controller
    {
        private TMDTDAEntities db = new TMDTDAEntities();

        // GET: Admin/DonHangVanChuyens
        public ActionResult Index()
        {
            return View(db.DonHangVanChuyens.ToList());
        }

        // GET: Admin/DonHangVanChuyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangVanChuyen donHangVanChuyen = db.DonHangVanChuyens.Find(id);
            if (donHangVanChuyen == null)
            {
                return HttpNotFound();
            }
            return View(donHangVanChuyen);
        }

        // GET: Admin/DonHangVanChuyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DonHangVanChuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingID,NgayGiaoHang,NgayNhanHang,TinhtrangDH,PhuongthucVC,PhiVC")] DonHangVanChuyen donHangVanChuyen)
        {
            if (ModelState.IsValid)
            {
                db.DonHangVanChuyens.Add(donHangVanChuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHangVanChuyen);
        }

        // GET: Admin/DonHangVanChuyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangVanChuyen donHangVanChuyen = db.DonHangVanChuyens.Find(id);
            if (donHangVanChuyen == null)
            {
                return HttpNotFound();
            }
            return View(donHangVanChuyen);
        }

        // POST: Admin/DonHangVanChuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingID,NgayGiaoHang,NgayNhanHang,TinhtrangDH,PhuongthucVC,PhiVC")] DonHangVanChuyen donHangVanChuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHangVanChuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHangVanChuyen);
        }

        // GET: Admin/DonHangVanChuyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHangVanChuyen donHangVanChuyen = db.DonHangVanChuyens.Find(id);
            if (donHangVanChuyen == null)
            {
                return HttpNotFound();
            }
            return View(donHangVanChuyen);
        }

        // POST: Admin/DonHangVanChuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHangVanChuyen donHangVanChuyen = db.DonHangVanChuyens.Find(id);
            db.DonHangVanChuyens.Remove(donHangVanChuyen);
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
