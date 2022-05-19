using DA_QLSach.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DA_QLSach.Controllers
{
    public class HomeController : Controller
    {
        dbSach db = new dbSach();
        public ActionResult Index(string id, int? page)
        {


            List<Sach> sachs = new List<Sach>();
            if (id == null)
            {
                sachs = db.Saches.Select(h => h).ToList();

            }
            else
            {

                sachs = db.Saches.Where(h => h.MaTG.Equals(id)).Select(h => h).ToList();
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(sachs.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult Tacgia(string id, int? page)
        {
            List<Sach> sachs = new List<Sach>();
            if (id == null)
            {
                sachs = db.Saches.Select(h => h).ToList();

            }
            else
            {
                sachs = db.Saches.Where(h => h.MaTG.ToString().Equals(id)).Select(h => h).ToList();
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sachs.ToPagedList(pageNumber, pageSize));
        }


        public PartialViewResult _Nav1()
        {
            var tg = db.TacGias.Select(n => n);
            return PartialView(tg);

        }
        public ActionResult _Detail(int? id)
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
                sachs = db.Saches.Where(h => h.MaTG.ToString().Equals(name)).Select(h => h).ToList();
            }
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return View(db.Saches.Where(p => p.TenSach.Contains(name)).OrderByDescending(x => x.TenSach).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}