using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laptop_Shop.ModelController;
using Laptop_Shop.Models;

namespace Laptop_Shop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index(string SearchString)
        {
            List<Category> categories = new List<Category>();
            categories = CateController.ViewCate();
            if (!String.IsNullOrEmpty(SearchString))
            {
                categories = CateController.searchCate(SearchString);
            }
            return View(categories);
        }
        public ActionResult FormAddCate()
        {
            return View();
        }
        public ActionResult addCate(Category category)
        {
            if(CateController.AddCate(category.cateName, category.cateDescription))
                return RedirectToAction("Index");
            return RedirectToAction("FormAddCate");
        }
        public ActionResult Delete(int id )
        {
            if(CateController.DelCate(id))
                return RedirectToAction("Index");
            return Content("<script language='javascript' type='text/javascript'>alert('Không thể xóa được');</script>");
        }
        public ActionResult Edit(int id)
        {
            CateController.get01cate(id);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CateController.EditCate(category.ID, category.cateName,category.cateDescription);
            return RedirectToAction("Index");
        }
    }
}