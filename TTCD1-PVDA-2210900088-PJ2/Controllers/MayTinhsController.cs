using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTCD1_PVDA_2210900088_PJ2.Models;

namespace TTCD1_PVDA_2210900088_PJ2.Controllers
{
    public class MayTinhsController : Controller
    {
        private quan_ly_tiem_netEntities db = new quan_ly_tiem_netEntities();

        // GET: MayTinhs
        public ActionResult Index()
        {
            return View(db.MayTinhs.ToList());
        }

        // GET: MayTinhs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayTinh mayTinh = db.MayTinhs.Find(id);
            if (mayTinh == null)
            {
                return HttpNotFound();
            }
            return View(mayTinh);
        }

        // GET: MayTinhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MayTinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_may_tinh,ten_may_tinh,trang_thai,vi_tri,ngay_tao")] MayTinh mayTinh)
        {
            if (ModelState.IsValid)
            {
                db.MayTinhs.Add(mayTinh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mayTinh);
        }

        // GET: MayTinhs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayTinh mayTinh = db.MayTinhs.Find(id);
            if (mayTinh == null)
            {
                return HttpNotFound();
            }
            return View(mayTinh);
        }

        // POST: MayTinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_may_tinh,ten_may_tinh,trang_thai,vi_tri,ngay_tao")] MayTinh mayTinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mayTinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mayTinh);
        }

        // GET: MayTinhs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayTinh mayTinh = db.MayTinhs.Find(id);
            if (mayTinh == null)
            {
                return HttpNotFound();
            }
            return View(mayTinh);
        }

        // POST: MayTinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MayTinh mayTinh = db.MayTinhs.Find(id);
            db.MayTinhs.Remove(mayTinh);
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
