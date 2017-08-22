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
    public class ChiTietHoaDonController : Controller
    {
        private ShopOnlineEntities db = new ShopOnlineEntities();

        // GET: Admin/ChiTietHoaDon
        public ActionResult Index()
        {
            var cTHoaDons = db.CTHoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(cTHoaDons.ToList());
        }

        // GET: Admin/ChiTietHoaDon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // GET: Admin/ChiTietHoaDon/Create
        public ActionResult Create()
        {
            ViewBag.ID_HoaDon = new SelectList(db.HoaDons, "ID_HoaDon", "TongTien");
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP");
            return View();
        }

        // POST: Admin/ChiTietHoaDon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SanPham,ID_HoaDon,SoLuong")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.CTHoaDons.Add(cTHoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HoaDon = new SelectList(db.HoaDons, "ID_HoaDon", "TongTien", cTHoaDon.ID_HoaDon);
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", cTHoaDon.ID_SanPham);
            return View(cTHoaDon);
        }

        // GET: Admin/ChiTietHoaDon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HoaDon = new SelectList(db.HoaDons, "ID_HoaDon", "TongTien", cTHoaDon.ID_HoaDon);
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", cTHoaDon.ID_SanPham);
            return View(cTHoaDon);
        }

        // POST: Admin/ChiTietHoaDon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SanPham,ID_HoaDon,SoLuong")] CTHoaDon cTHoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HoaDon = new SelectList(db.HoaDons, "ID_HoaDon", "TongTien", cTHoaDon.ID_HoaDon);
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", cTHoaDon.ID_SanPham);
            return View(cTHoaDon);
        }

        // GET: Admin/ChiTietHoaDon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            if (cTHoaDon == null)
            {
                return HttpNotFound();
            }
            return View(cTHoaDon);
        }

        // POST: Admin/ChiTietHoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTHoaDon cTHoaDon = db.CTHoaDons.Find(id);
            db.CTHoaDons.Remove(cTHoaDon);
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
