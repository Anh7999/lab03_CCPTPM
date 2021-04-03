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
    public class GiasController : Controller
    {
        private TMDTDAEntities db = new TMDTDAEntities();

        // GET: Admin/Gias
        public ActionResult Index()
        {
            return View(db.Gias.ToList());
        }

        // GET: Admin/Gias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gia gia = db.Gias.Find(id);
            if (gia == null)
            {
                return HttpNotFound();
            }
            return View(gia);
        }

        // GET: Admin/Gias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Gias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMucgia,Dongia,Ngayapdung,Ngayketthuc")] Gia gia)
        {
            if (ModelState.IsValid)
            {
                db.Gias.Add(gia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gia);
        }

        // GET: Admin/Gias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gia gia = db.Gias.Find(id);
            if (gia == null)
            {
                return HttpNotFound();
            }
            return View(gia);
        }

        // POST: Admin/Gias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMucgia,Dongia,Ngayapdung,Ngayketthuc")] Gia gia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gia);
        }

        // GET: Admin/Gias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gia gia = db.Gias.Find(id);
            if (gia == null)
            {
                return HttpNotFound();
            }
            return View(gia);
        }

        // POST: Admin/Gias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gia gia = db.Gias.Find(id);
            db.Gias.Remove(gia);
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
