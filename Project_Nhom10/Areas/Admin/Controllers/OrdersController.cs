using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom10.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Orders
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index(string search = "", int page = 1)
        {
            List<DONHANG> lst = db.DONHANGs.Where(t => t.TAIKHOAN.Contains(search)).ToList();
            ViewBag.search = search;
            int NoOfRecordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lst.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.NoOfPages = NoOfPages;
            lst = lst.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lst);
        }
        public ActionResult detail(int id)
        {
            List<CHITIETDONHANG> lst = db.CHITIETDONHANGs.Where(t => t.MADONHANG == id).ToList();
            ViewBag.id = id;
            return View(lst);
        }
        [HttpPost]
        public ActionResult delete(int id)
        {
            List<CHITIETDONHANG> lst = db.CHITIETDONHANGs.Where(t => t.MADONHANG == id).ToList();
            foreach (var i in lst)
            {
                db.CHITIETDONHANGs.Remove(i);
                db.SaveChanges();
            }
            DONHANG dh = db.DONHANGs.Where(t => t.MADONHANG == id).FirstOrDefault();
            db.DONHANGs.Remove(dh);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult confirm(int id)
        {
            DONHANG dh = db.DONHANGs.Where(t => t.MADONHANG == id).FirstOrDefault();
            dh.TINHTRANGDH = "Đang chuẩn bị hàng";
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}