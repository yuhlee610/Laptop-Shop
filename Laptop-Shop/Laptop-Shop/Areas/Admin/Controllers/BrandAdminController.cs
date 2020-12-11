using Laptop_Shop.ModelController;
using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop_Shop.Areas.Admin.Controllers
{
    public class BrandAdminController : Controller
    {
        // GET: Admin/BrandAdmin
        public ActionResult Index(string SearchString)
        {
            List<Brand> brands = new List<Brand>();
            brands = BrandController.ViewBrands();
            if (!String.IsNullOrEmpty(SearchString))
            {
                brands = BrandController.SearchBrands(SearchString);
            }
            return View(brands);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            if (BrandController.AddBrands(brand.brandName, brand.brandDescription, brand.brandHomePage))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            if (BrandController.EditBrands(brand.ID, brand.brandName, brand.brandDescription, brand.brandHomePage))
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Delete(int id)
        {
            if (BrandController.DeleteBrands(id))
                return RedirectToAction("Index");
            return Content("<script language='javascript' type='text/javascript'>alert('Không thể xóa được');</script>");
        }
    }
}