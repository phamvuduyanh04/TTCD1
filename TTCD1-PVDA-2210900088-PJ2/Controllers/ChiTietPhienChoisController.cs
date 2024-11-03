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
    public class ChiTietPhienChoisController : Controller
    {
        private quan_ly_tiem_netEntities db = new quan_ly_tiem_netEntities();

        // GET: ChiTietPhienChois
        public ActionResult Index()
        {
            var chiTietPhienChois = db.ChiTietPhienChois.Include(c => c.MayTinh).Include(c => c.PhienChoi);
            return View(chiTietPhienChois.ToList());
        }

        // GET: ChiTietPhienChois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhienChoi chiTietPhienChoi = db.ChiTietPhienChois.Find(id);
            if (chiTietPhienChoi == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhienChoi);
        }

        // GET: ChiTietPhienChois/Create
        public ActionResult Create()
        {
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh");
            ViewBag.ma_phien = new SelectList(db.PhienChois, "ma_phien", "trang_thai");
            return View();
        }

        // POST: ChiTietPhienChois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_chi_tiet,ma_phien,ma_may_tinh,thoi_gian_vao,thoi_gian_ra,thoi_luong")] ChiTietPhienChoi chiTietPhienChoi)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietPhienChois.Add(chiTietPhienChoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", chiTietPhienChoi.ma_may_tinh);
            ViewBag.ma_phien = new SelectList(db.PhienChois, "ma_phien", "trang_thai", chiTietPhienChoi.ma_phien);
            return View(chiTietPhienChoi);
        }

        // GET: ChiTietPhienChois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhienChoi chiTietPhienChoi = db.ChiTietPhienChois.Find(id);
            if (chiTietPhienChoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", chiTietPhienChoi.ma_may_tinh);
            ViewBag.ma_phien = new SelectList(db.PhienChois, "ma_phien", "trang_thai", chiTietPhienChoi.ma_phien);
            return View(chiTietPhienChoi);
        }

        // POST: ChiTietPhienChois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_chi_tiet,ma_phien,ma_may_tinh,thoi_gian_vao,thoi_gian_ra,thoi_luong")] ChiTietPhienChoi chiTietPhienChoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietPhienChoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", chiTietPhienChoi.ma_may_tinh);
            ViewBag.ma_phien = new SelectList(db.PhienChois, "ma_phien", "trang_thai", chiTietPhienChoi.ma_phien);
            return View(chiTietPhienChoi);
        }

        // GET: ChiTietPhienChois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietPhienChoi chiTietPhienChoi = db.ChiTietPhienChois.Find(id);
            if (chiTietPhienChoi == null)
            {
                return HttpNotFound();
            }
            return View(chiTietPhienChoi);
        }

        // POST: ChiTietPhienChois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietPhienChoi chiTietPhienChoi = db.ChiTietPhienChois.Find(id);
            db.ChiTietPhienChois.Remove(chiTietPhienChoi);
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
