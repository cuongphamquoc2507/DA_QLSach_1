using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DA_QLSach.Models;

namespace DA_QLSach.Controllers
{
    public class DonHangsController : Controller
    {
        private dbSach db = new dbSach();

        // GET: DonHangs
        public ActionResult Index()
        {
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            KhachHang kh = (KhachHang)Session["use"];
            int maND = kh.IDKhachHang;
            var donhangs = db.DonHangs.Include(d => d.KhachHang).Where(d => d.IDKhachHang == maND);
            return View(donhangs.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            var chitiet = db.CT_HoaDon.Include(d => d.Sach).Where(d => d.IDHoaDon == id).ToList();
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(chitiet);
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.IDKhachHang = new SelectList(db.KhachHangs, "IDKhachHang", "TenKH");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDHoaDon,NgayDat,TinhTrang,IDKhachHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDKhachHang = new SelectList(db.KhachHangs, "IDKhachHang", "TenKH", donHang.IDKhachHang);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDKhachHang = new SelectList(db.KhachHangs, "IDKhachHang", "TenKH", donHang.IDKhachHang);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDHoaDon,NgayDat,TinhTrang,IDKhachHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDKhachHang = new SelectList(db.KhachHangs, "IDKhachHang", "TenKH", donHang.IDKhachHang);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donHang);
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
