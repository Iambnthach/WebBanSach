using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Project_Nhom10.Models;

namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class PublishersController : Controller
    {
        // GET: Admin/Publishers
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            List<NHAXUATBAN> lst = db.NHAXUATBANs.ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult create(NHAXUATBAN nxb)
        {
            if (ModelState.IsValid)
            {
                db.NHAXUATBANs.Add(nxb);
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
            List<SACH> lst = db.SACHes.Where(t => t.MANXB == id).ToList();
            if(lst.Count != 0)
            {
                foreach(var i in lst)
                {
                    i.MANXB = 2003;
                    db.SaveChanges();
                }    
            }
            NHAXUATBAN nxb = db.NHAXUATBANs.Where(t => t.MANXB == id).FirstOrDefault();
            db.NHAXUATBANs.Remove(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}