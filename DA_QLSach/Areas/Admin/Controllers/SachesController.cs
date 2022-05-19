using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DA_QLSach.Areas.Admin.Data;
using PagedList;

namespace DA_QLSach.Areas.Admin.Controllers
{
    public class SachesController : Controller
    {
        private adminbook db = new adminbook();

        // GET: Admin/Saches
        public ActionResult Index(string id, int? page)
        {
            //return View(db.TACGIAs.ToList());
            List<Sach> saches = new List<Sach>();
            if (id == null)
            {
                saches = db.Saches.Select(h => h).ToList();

            }
            else
            {
                saches = db.Saches.Where(h => h.MaSach.ToString().Equals(id)).Select(h => h).ToList();
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(saches.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Saches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Admin/Saches/Create
        public ActionResult Create()
        {
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG");
            return View();
        }

        // POST: Admin/Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaTG,TenSach,anh,Mota,Gia,SoLuong")] Sach sach, HttpPostedFileBase file)
        {

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        sach.anh = "";
            //        var f = Request.Files["ImageFile"];
            //        if (f != null && f.ContentLength > 0)
            //        {
            //            string nameFile = Path.GetFileName(fileUpload.FileName);
            //            fileUpload.SaveAs(Path.Combine(Server.MapPath("~/Areas/Asset/images/"), nameFile));
            //            sach.anh = "~/Areas/Asset/images/ " + nameFile;
            //        }

            //        db.Saches.Add(sach);
            //        db.SaveChanges();

            //    }
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)

            //{
            //    ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            //    ViewBag.Error = "Lỗi nhập dữ liệu" + e.Message;

            //    return View(sach);
            //}
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            var pro = db.Saches.SingleOrDefault(c => c.MaSach.Equals(sach.MaSach));
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    try
                    {
                        string FileName = System.IO.Path.GetFileName(file.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        file.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        sach.anh = FileName;
                    }
                    catch (Exception)
                    {
                        ViewBag.CreateProError = "Không thể chọn ảnh.";
                    }
                }

                try
                {
                    if (pro != null)
                    {
                        ViewBag.CreateProError = "Mã sản phẩm đã tồn tại.";
                    }
                    else
                    {

                        db.Saches.Add(sach);
                        db.SaveChanges();
                        ViewBag.CreateProError = "Thêm sản phẩm thành công.";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.CreateProError = "Không thể thêm sản phẩm.";
                }
            }
            else
            {
                ViewBag.HinhAnh = "Vui lòng chọn hình ảnh.";
            }
            return View();
        }

        // GET: Admin/Saches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            return View(sach);
        }

        // POST: Admin/Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaTG,TenSach,anh,Mota,Gia,SoLuong")] Sach sach, HttpPostedFileBase file)
        {
            ViewBag.MaTG = new SelectList(db.TacGias, "MaTG", "TenTG", sach.MaTG);
            var pro = db.Saches.SingleOrDefault(c => c.MaSach.Equals(sach.MaSach));
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    try
                    {
                        string FileName = System.IO.Path.GetFileName(file.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/wwwroot/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        file.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        sach.anh = FileName;
                    }
                    catch (Exception)
                    {
                        ViewBag.CreateProError = "Không thể chọn ảnh.";
                    }
                }

                try
                {
                    if (pro != null)
                    {
                        ViewBag.CreateProError = "Mã sản phẩm đã tồn tại.";
                    }
                    else
                    {

                        db.Entry(sach).State = EntityState.Modified;
                        db.SaveChanges();
                        ViewBag.CreateProError = "Thêm sản phẩm thành công.";
                    }
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.CreateProError = "Không thể thêm sản phẩm.";
                }
            }
            else
            {
                ViewBag.HinhAnh = "Vui lòng chọn hình ảnh.";
            }
            return View();
        }

        // GET: Admin/Saches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Admin/Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchByName(string name, int? page)
        {
            ViewBag.search = name;
            List<Sach> sachs = new List<Sach>();
            if (name == null)
            {
                sachs = db.Saches.Select(h => h).ToList();

            }
            else
            {
                sachs = db.Saches.Where(h => h.TenSach.ToString().Equals(name)).Select(h => h).ToList();
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(db.Saches.Where(p => p.TenSach.Contains(name)).OrderByDescending(x => x.TenSach).ToPagedList(pageNumber, pageSize));
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
