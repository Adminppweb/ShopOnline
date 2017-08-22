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
    public class NhanXetController : Controller
    {
        private ShopOnlineEntities db = new ShopOnlineEntities();

        // GET: Admin/NhanXet
        public ActionResult Index()
        {
            var nhanXets = db.NhanXets.Include(n => n.SanPham).Include(n => n.ThanhVien);
            return View(nhanXets.ToList());
        }

        // GET: Admin/NhanXet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanXet nhanXet = db.NhanXets.Find(id);
            if (nhanXet == null)
            {
                return HttpNotFound();
            }
            return View(nhanXet);
        }

        // GET: Admin/NhanXet/Create
        public ActionResult Create()
        {
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP");
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan");
            return View();
        }

        // POST: Admin/NhanXet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NX,ID_SanPham,ID_ThanhVien,NoiDung")] NhanXet nhanXet)
        {
            if (ModelState.IsValid)
            {
                db.NhanXets.Add(nhanXet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", nhanXet.ID_SanPham);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", nhanXet.ID_ThanhVien);
            return View(nhanXet);
        }

        // GET: Admin/NhanXet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanXet nhanXet = db.NhanXets.Find(id);
            if (nhanXet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", nhanXet.ID_SanPham);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", nhanXet.ID_ThanhVien);
            return View(nhanXet);
        }

        // POST: Admin/NhanXet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NX,ID_SanPham,ID_ThanhVien,NoiDung")] NhanXet nhanXet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanXet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SanPham = new SelectList(db.SanPhams, "ID_SP", "TenSP", nhanXet.ID_SanPham);
            ViewBag.ID_ThanhVien = new SelectList(db.ThanhViens, "ID_TV", "TaiKhoan", nhanXet.ID_ThanhVien);
            return View(nhanXet);
        }

        // GET: Admin/NhanXet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanXet nhanXet = db.NhanXets.Find(id);
            if (nhanXet == null)
            {
                return HttpNotFound();
            }
            return View(nhanXet);
        }

        // POST: Admin/NhanXet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanXet nhanXet = db.NhanXets.Find(id);
            db.NhanXets.Remove(nhanXet);
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
