using DA_QLSach.Areas.Admin.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA_QLSach.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        adminbook db = new adminbook();
        // GET: Admin/Home
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(string TenDN, string MatKhau)
        {

            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.TenDN.Equals(TenDN) && u.MatKhau.Equals(MatKhau) && u.PhanQuyen == "admin").ToList();
                var user1 = db.TaiKhoans.Where(u => u.TenDN.Equals(TenDN) && u.MatKhau.Equals(MatKhau) && u.PhanQuyen == "client").ToList();
                if (user.Count() > 0)

                {                     //sử dụng Session: add Session
                    Session["TenDN"] = user.FirstOrDefault().TenDN;
                    Session["MatKhau"] = user.FirstOrDefault().MatKhau;
                    Session["MaTK"] = user.FirstOrDefault().MaTK;
                    return RedirectToAction("Index");
                }
               
                else
                {
                    ViewBag.error = "Đăng nhập không thành công!";
                }
            }
            return View();
        }

       
        public ActionResult tacgia()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "MaTK,TenDN,MatKhau,PhanQuyen")] TaiKhoan tAIKHOAN)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(tAIKHOAN);
                db.SaveChanges();
                return RedirectToAction("login");
            }

            return View(tAIKHOAN);
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("login");
        }
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult TonKho(string id, int? page)
        //{
        //    List<Sach> sachs = new List<Sach>();
        //    if (id == null)
        //    {
        //        sachs = db.Saches.Select(h => h).ToList();

        //    }
        //    else
        //    {
        //        sachs = db.Saches.Where(h => h.MaTG.ToString().Equals(id)).Select(h => h).ToList();
        //    }
        //    int pageSize = 4;
        //    int pageNumber = (page ?? 1);
        //    return View(sachs.ToPagedList(pageNumber, pageSize));
        //}
        //public ActionResult SearchByName(string name, int? page)
        //{
        //    ViewBag.search = name;
        //    List<Sach> sachs = new List<Sach>();
        //    if (name == null)
        //    {
        //        sachs = db.Saches.Select(h => h).ToList();

        //    }
        //    else
        //    {
        //        sachs = db.Saches.Where(h => h.MaTG.ToString().Equals(name)).Select(h => h).ToList();
        //    }
        //    int pageSize = 8;
        //    int pageNumber = (page ?? 1);

        //    return View(db.Saches.Where(p => p.TenSach.Contains(name)).OrderByDescending(x => x.TenSach).ToPagedList(pageNumber, pageSize));
        //}
    }
}