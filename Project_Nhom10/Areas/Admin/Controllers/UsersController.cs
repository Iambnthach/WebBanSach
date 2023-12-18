using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom10.Models;
using System.ComponentModel.DataAnnotations;
namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            List<TAIKHOAN> lst = db.TAIKHOANs.ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult delete(string username)
        {
            TAIKHOAN tk = db.TAIKHOANs.Where(r => r.TAIKHOAN1 == username).FirstOrDefault();
            db.TAIKHOANs.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}