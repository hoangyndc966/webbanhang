using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        WebBanHangEntities2 objWebBanHangEntities2 = new WebBanHangEntities2();
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var ojbproduct = objWebBanHangEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(ojbproduct);
        }
        public ActionResult ProductCategory()
        {
            return View();
        }
    }
}