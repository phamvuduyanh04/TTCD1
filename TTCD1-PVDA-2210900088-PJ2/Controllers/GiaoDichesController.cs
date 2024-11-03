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
    public class GiaoDichesController : Controller
    {
        private quan_ly_tiem_netEntities db = new quan_ly_tiem_netEntities();

        // GET: GiaoDiches
        public ActionResult Index()
        {
            var giaoDiches = db.GiaoDiches.Include(g => g.NguoiDung);
            return View(giaoDiches.ToList());
        }

        // GET: GiaoDiches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            return View(giaoDich);
        }

        // GET: GiaoDiches/Create
        public ActionResult Create()
        {
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap");
            return View();
        }

        // POST: GiaoDiches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_giao_dich,ma_nguoi_dung,loai_giao_dich,so_tien,ngay_giao_dich")] GiaoDich giaoDich)
        {
            if (ModelState.IsValid)
            {
                db.GiaoDiches.Add(giaoDich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", giaoDich.ma_nguoi_dung);
            return View(giaoDich);
        }

        // GET: GiaoDiches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", giaoDich.ma_nguoi_dung);
            return View(giaoDich);
        }

        // POST: GiaoDiches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_giao_dich,ma_nguoi_dung,loai_giao_dich,so_tien,ngay_giao_dich")] GiaoDich giaoDich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoDich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", giaoDich.ma_nguoi_dung);
            return View(giaoDich);
        }

        // GET: GiaoDiches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            if (giaoDich == null)
            {
                return HttpNotFound();
            }
            return View(giaoDich);
        }

        // POST: GiaoDiches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaoDich giaoDich = db.GiaoDiches.Find(id);
            db.GiaoDiches.Remove(giaoDich);
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
