using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DA_QLSach.Areas.Admin.Data;
using PagedList;

namespace DA_QLSach.Areas.Admin.Controllers
{
    public class TacGiasController : Controller
    {
        private adminbook db = new adminbook();

        // GET: Admin/TacGias
        public ActionResult Index(string id, int? page)
        {
            //return View(db.TACGIAs.ToList());
            List<TacGia> tacgias = new List<TacGia>();
            if (id == null)
            {
                tacgias = db.TacGias.Select(h => h).ToList();

            }
            else
            {
                tacgias = db.TacGias.Where(h => h.MaTG.ToString().Equals(id)).Select(h => h).ToList();
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(tacgias.ToPagedList(pageNumber, pageSize));
        }


        // GET: Admin/TacGias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // GET: Admin/TacGias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TacGias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTG,TenTG,Anh,Ngaysinh,Quequan,Tieusu")] TacGia tacGia)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    tacGia.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use  Namespace  called  :	System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/Areas/Asset/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        f.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        tacGia.Anh = FileName;
                    }

                    db.TacGias.Add(tacGia);
                    db.SaveChanges();
                    //SetAlter("Thêm thành công", "success");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;

                return View(tacGia);

            }
        }


        // GET: Admin/TacGias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: Admin/TacGias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTG,TenTG,Anh,Ngaysinh,Quequan,Tieusu")] TacGia tacGia)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    tacGia.Anh = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        //Use  Namespace  called  :	System.IO
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        //Lấy  tên  file  upload
                        string UploadPath = Server.MapPath("~/Areas/Asset/images/" + FileName);
                        //Copy  Và  lưu  file  vào  server.
                        f.SaveAs(UploadPath);
                        //Lưu  tên  file  vào  trường
                        tacGia.Anh = FileName;
                    }
                    db.Entry(tacGia).State = EntityState.Modified;
                    db.SaveChanges();

                    db.SaveChanges();
                    //SetAlter("Thêm thành công", "success");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;

                return View(tacGia);

            }
        }

        // GET: Admin/TacGias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TacGia tacGia = db.TacGias.Find(id);
            if (tacGia == null)
            {
                return HttpNotFound();
            }
            return View(tacGia);
        }

        // POST: Admin/TacGias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TacGia tacGia = db.TacGias.Find(id);
            db.TacGias.Remove(tacGia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchByName(string name, int? page)
        {
            ViewBag.search = name;
            List<TacGia> tacgias = new List<TacGia>();
            if (name == null)
            {
                tacgias = db.TacGias.Select(h => h).ToList();

            }
            else
            {
                tacgias = db.TacGias.Where(h => h.TenTG.ToString().Equals(name)).Select(h => h).ToList();
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(db.TacGias.Where(p => p.TenTG.Contains(name)).OrderByDescending(x => x.TenTG).ToPagedList(pageNumber, pageSize));
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
