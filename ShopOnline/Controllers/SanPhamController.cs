using System;
using ShopOnlineBus.Bus;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopOnline.Controllers
{
    public class SanPhamController : Controller
    {
            // GET: SanPham
            public ActionResult Index()
            {
                return View(SanPhamBus.List());
            }

        // GET: SanPham/Details/5
            public ActionResult Details(int id)
            {
                return View(SanPhamBus.GetById(id));
            }
    }
}
