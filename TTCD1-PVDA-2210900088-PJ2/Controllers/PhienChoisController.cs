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
    public class PhienChoisController : Controller
    {
        private quan_ly_tiem_netEntities db = new quan_ly_tiem_netEntities();

        // GET: PhienChois
        public ActionResult Index()
        {
            var phienChois = db.PhienChois.Include(p => p.MayTinh).Include(p => p.NguoiDung);
            return View(phienChois.ToList());
        }

        // GET: PhienChois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhienChoi phienChoi = db.PhienChois.Find(id);
            if (phienChoi == null)
            {
                return HttpNotFound();
            }
            return View(phienChoi);
        }

        // GET: PhienChois/Create
        public ActionResult Create()
        {
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh");
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap");
            return View();
        }

        // POST: PhienChois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_phien,ma_nguoi_dung,ma_may_tinh,thoi_gian_bat_dau,thoi_gian_ket_thuc,tong_thoi_gian,tong_chi_phi,trang_thai")] PhienChoi phienChoi)
        {
            if (ModelState.IsValid)
            {
                db.PhienChois.Add(phienChoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", phienChoi.ma_may_tinh);
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", phienChoi.ma_nguoi_dung);
            return View(phienChoi);
        }

        // GET: PhienChois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhienChoi phienChoi = db.PhienChois.Find(id);
            if (phienChoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", phienChoi.ma_may_tinh);
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", phienChoi.ma_nguoi_dung);
            return View(phienChoi);
        }

        // POST: PhienChois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_phien,ma_nguoi_dung,ma_may_tinh,thoi_gian_bat_dau,thoi_gian_ket_thuc,tong_thoi_gian,tong_chi_phi,trang_thai")] PhienChoi phienChoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phienChoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_may_tinh = new SelectList(db.MayTinhs, "ma_may_tinh", "ten_may_tinh", phienChoi.ma_may_tinh);
            ViewBag.ma_nguoi_dung = new SelectList(db.NguoiDungs, "ma_nguoi_dung", "ten_dang_nhap", phienChoi.ma_nguoi_dung);
            return View(phienChoi);
        }

        // GET: PhienChois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhienChoi phienChoi = db.PhienChois.Find(id);
            if (phienChoi == null)
            {
                return HttpNotFound();
            }
            return View(phienChoi);
        }

        // POST: PhienChois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhienChoi phienChoi = db.PhienChois.Find(id);
            db.PhienChois.Remove(phienChoi);
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
