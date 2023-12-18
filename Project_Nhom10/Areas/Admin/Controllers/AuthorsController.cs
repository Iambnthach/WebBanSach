using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom10.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Admin/Authors
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            List<TACGIA> lst = db.TACGIAs.ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult create(TACGIA tg)
        {
            if (ModelState.IsValid)
            {
                db.TACGIAs.Add(tg);
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
            TACGIA tg = db.TACGIAs.Where(t => t.MATG == id).FirstOrDefault();
            db.TACGIAs.Remove(tg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}