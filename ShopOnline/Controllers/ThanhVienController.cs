using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class ThanhVienController : Controller
    {
        // GET: ThanhVien
        public ActionResult Index()
        {
            return View();
        }

        // GET: ThanhVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ThanhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThanhVien/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThanhVien/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ThanhVien/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ThanhVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ThanhVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
