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
    public class SanPhamController : Controller
    {
        private ShopOnlineEntities db = new ShopOnlineEntities();

        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.LoaiSP).Include(s => s.NhaSanXuat).Include(s => s.UserAdmin);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.ID_LoaiSP = new SelectList(db.LoaiSPs, "ID_Loai", "TenLoai");
            ViewBag.ID_NhaSanXuat = new SelectList(db.NhaSanXuats, "ID_NSX", "TenNSX");
            ViewBag.ID_User = new SelectList(db.UserAdmins, "ID_UD", "UserName");
            return View();
        }

        // POST: Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SP,TenSP,GiaBan,MoTa,SoLuongTon,SoLuongBan,TinhTrangSP,ID_LoaiSP,ID_NhaSanXuat,NgayNhap,HinhAnhSP,ID_User")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LoaiSP = new SelectList(db.LoaiSPs, "ID_Loai", "TenLoai", sanPham.ID_LoaiSP);
            ViewBag.ID_NhaSanXuat = new SelectList(db.NhaSanXuats, "ID_NSX", "TenNSX", sanPham.ID_NhaSanXuat);
            ViewBag.ID_User = new SelectList(db.UserAdmins, "ID_UD", "UserName", sanPham.ID_User);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LoaiSP = new SelectList(db.LoaiSPs, "ID_Loai", "TenLoai", sanPham.ID_LoaiSP);
            ViewBag.ID_NhaSanXuat = new SelectList(db.NhaSanXuats, "ID_NSX", "TenNSX", sanPham.ID_NhaSanXuat);
            ViewBag.ID_User = new SelectList(db.UserAdmins, "ID_UD", "UserName", sanPham.ID_User);
            return View(sanPham);
        }

        // POST: Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SP,TenSP,GiaBan,MoTa,SoLuongTon,SoLuongBan,TinhTrangSP,ID_LoaiSP,ID_NhaSanXuat,NgayNhap,HinhAnhSP,ID_User")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LoaiSP = new SelectList(db.LoaiSPs, "ID_Loai", "TenLoai", sanPham.ID_LoaiSP);
            ViewBag.ID_NhaSanXuat = new SelectList(db.NhaSanXuats, "ID_NSX", "TenNSX", sanPham.ID_NhaSanXuat);
            ViewBag.ID_User = new SelectList(db.UserAdmins, "ID_UD", "UserName", sanPham.ID_User);
            return View(sanPham);
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
