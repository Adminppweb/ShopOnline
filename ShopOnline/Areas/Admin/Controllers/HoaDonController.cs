using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Areas;

namespace ShopOnline.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        private ShopOnlineEntities db = new ShopOnlineEntities();

        // GET: Admin/HoaDon
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.ThanhVien);
            return View(hoaDons.ToList());
        }

        // GET: Admin/HoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Create
        public ActionResult Create()
        {
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan");
            return View();
        }

        // POST: Admin/HoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HoaDon,ID_ThanhVien,ThoiGianMua,TongTien,TinhTrang_HD")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", hoaDon.ID_ThanhVien);
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", hoaDon.ID_ThanhVien);
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HoaDon,ID_ThanhVien,ThoiGianMua,TongTien,TinhTrang_HD")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", hoaDon.ID_ThanhVien);
            return View(hoaDon);
        }

        // GET: Admin/HoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
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
