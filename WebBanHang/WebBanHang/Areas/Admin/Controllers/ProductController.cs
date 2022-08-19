﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;
using static WebBanHang.Common;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebBanHangEntities2 objWebBanHangEntities2 = new WebBanHangEntities2();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var lstProduct = objWebBanHangEntities2.Products.ToList();
            return View(lstProduct);
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objWebBanHangEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {

                    if (objProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        //tenhinh
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        // tenhinh.png
                        objProduct.Avartar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objWebBanHangEntities2.CreateOnUtc = DateTime.Now;
                    objWebBanHangEntities2.Products.Add(objProduct);
                    objWebBanHangEntities2.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();

                }
            }
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = objWebBanHangEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {
            var objProduct = objWebBanHangEntities2.Products.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebBanHangEntities2.Products.Remove(objProduct);
            objWebBanHangEntities2.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public ActionResult Edit(int Id)
        //{
        //    var objProduct = objWebBanHangEntities2.Products.Where(n => n.Id == Id).FirstOrDefault();
        //    return View(objProduct);
        //}
        //[HttpPost]
        //public ActionResult Edit(int Id, Product objProduct)
        //{
        //    if (objProduct.ImageUpload != null)
        //    {
        //        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
        //        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
        //        fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
        //        objProduct.Avartar = fileName;
        //        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
        //    }
        //    objWebBanHangEntities2.Entry(objProduct).State = EntityState.Modified;
        //    objWebBanHangEntities2.SaveChanges();
        //    return RedirectToAction("Index");

        //}
        void LoadData()
        {
            Common objCommon = new Common();
            // lấy dữ liệu danh mục dưới DB
            var lstCat = objWebBanHangEntities2.Categories.ToList();
            //convert sang select list dạng value, text 
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");

            //lấy dữ liệu thương hiệu dưới DB
            var lstBrand = objWebBanHangEntities2.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            // convert sang select list dạng value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01;
            objProductType.Name = "Giảm giá sốc";
            lstProductType.Add(objProductType);

            objProductType = new ProductType();
            objProductType.Id = 02;
            objProductType.Name = "Đề xuất";
            lstProductType.Add(objProductType);

            DataTable dtProductType = converter.ToDataTable(lstProductType);
            // convert sang select list dạng value, text
            ViewBag.ProductType = objCommon.ToSelectList(dtProductType, "Id", "Name");

        }
    }
 }

