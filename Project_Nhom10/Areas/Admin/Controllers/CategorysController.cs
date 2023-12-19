using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Project_Nhom10.Models;

namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class CategorysController : Controller
    {
        // GET: Admin/Categorys
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            List<THELOAI> lst = db.THELOAIs.ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult create(THELOAI tl)
        {
            if (ModelState.IsValid)
            {
                db.THELOAIs.Add(tl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult delete(int id)
        {
            List<SACH> lst = db.SACHes.Where(t => t.MATL == id).ToList();
            if(lst.Count != 0)
            {
                foreach(SACH i in lst)
                {
                    i.MATL = 2002;
                    db.SaveChanges();
                }
            }      
            THELOAI tl = db.THELOAIs.Where(t => t.MATL == id).FirstOrDefault();
            db.THELOAIs.Remove(tl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}