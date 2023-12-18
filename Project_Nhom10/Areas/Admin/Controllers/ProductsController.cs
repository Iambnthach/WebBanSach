using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Nhom10.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Web.UI;

namespace Project_Nhom10.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Admin/Products

        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index(string search = "", int page = 1)
        {
            List<SACH> lst = db.SACHes.Where(t => t.TENSACH.Contains(search)).ToList();
            ViewBag.search = search;
            int NoOfRecordPerPage = 8;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(lst.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.page = page;
            ViewBag.NoOfPages = NoOfPages;
            lst = lst.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(lst);
        }
        public ActionResult create()
        {
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            ViewBag.tacgia = tacgia;
            List<THELOAI> theloai = db.THELOAIs.ToList();
            ViewBag.theloai = theloai;
            List<NHAXUATBAN> nhaxuatban = db.NHAXUATBANs.ToList();
            ViewBag.nhaxuatban = nhaxuatban;
            return View();
        }
        [HttpPost]
        public ActionResult create(SACH book)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult update(int id)
        {
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            ViewBag.tacgia = tacgia;
            List<THELOAI> theloai = db.THELOAIs.ToList();
            ViewBag.theloai = theloai;
            List<NHAXUATBAN> nhaxuatban = db.NHAXUATBANs.ToList();
            ViewBag.nhaxuatban = nhaxuatban;
            SACH s = db.SACHes.Where(t => t.MASACH == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult update(SACH sach)
        {
            SACH s = db.SACHes.Where(t => t.MASACH == sach.MASACH).FirstOrDefault();
            if (ModelState.IsValid)
            {
                s.TENSACH = sach.TENSACH;
                s.GIA = sach.GIA;
                s.GIAMGIA = sach.GIAMGIA;
                s.SOLUONGTON = sach.SOLUONGTON;
                s.MATL = sach.MATL;
                s.MATG = sach.MATG;
                s.MANXB = sach.MANXB;
                s.MOTA = sach.MOTA;
                s.HINHANH = sach.HINHANH;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult delete(int id)
        {
            List<TACGIA> tacgia = db.TACGIAs.ToList();
            ViewBag.tacgia = tacgia;
            List<THELOAI> theloai = db.THELOAIs.ToList();
            ViewBag.theloai = theloai;
            List<NHAXUATBAN> nhaxuatban = db.NHAXUATBANs.ToList();
            ViewBag.nhaxuatban = nhaxuatban;
            SACH s = db.SACHes.Where(t => t.MASACH == id).FirstOrDefault();
            return View(s);
        }
        [HttpPost]
        public ActionResult delete(int id, string name)
        {
            SACH s = db.SACHes.Where(t => t.MASACH == id).FirstOrDefault();
            db.SACHes.Remove(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}