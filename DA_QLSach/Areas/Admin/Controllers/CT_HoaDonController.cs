using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DA_QLSach.Areas.Admin.Data;

namespace DA_QLSach.Areas.Admin.Controllers
{
    public class CT_HoaDonController : Controller
    {
        private adminbook db = new adminbook();
      

        // GET: Admin/CT_HoaDon
        public ActionResult Index()
        {
            var cT_HoaDon = db.CT_HoaDon.Include(c => c.DonHang).Include(c => c.Sach);
            var tong = db.CT_HoaDon.Sum(c => c.Thanhtien).Value.ToString();
            ViewBag.tong = tong;
            return View(cT_HoaDon.ToList());
        }

        // GET: Admin/CT_HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.IDHoaDon = new SelectList(db.DonHangs, "IDHoaDon", "TinhTrang");
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: Admin/CT_HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHoaDon,MaSach,Sluong,Dongia,Thanhtien")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CT_HoaDon.Add(cT_HoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDHoaDon = new SelectList(db.DonHangs, "IDHoaDon", "TinhTrang", cT_HoaDon.IDHoaDon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cT_HoaDon.MaSach);
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDHoaDon = new SelectList(db.DonHangs, "IDHoaDon", "TinhTrang", cT_HoaDon.IDHoaDon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cT_HoaDon.MaSach);
            return View(cT_HoaDon);
        }

        // POST: Admin/CT_HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHoaDon,MaSach,Sluong,Dongia,Thanhtien")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDHoaDon = new SelectList(db.DonHangs, "IDHoaDon", "TinhTrang", cT_HoaDon.IDHoaDon);
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", cT_HoaDon.MaSach);
            return View(cT_HoaDon);
        }

        // GET: Admin/CT_HoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            if (cT_HoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cT_HoaDon);
        }

        // POST: Admin/CT_HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HoaDon cT_HoaDon = db.CT_HoaDon.Find(id);
            db.CT_HoaDon.Remove(cT_HoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //private int TongTien(int? Tong)
        //{

        //    List<CT_HoaDon> cT_Hoas = Session["CT_HoaDon"] as List<CT_HoaDon>;
        //    if (cT_Hoas != null)
        //    {
        //        Tong = cT_Hoas.Sum(n => n.Thanhtien);
        //    }
        //    return Tong;
        //}
        //public ActionResult Total_money()
        //{

        //    ViewBag.TongTien = Tong();
        //    return PartialView();
        //}

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
