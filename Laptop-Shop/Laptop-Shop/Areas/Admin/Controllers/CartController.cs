using Laptop_Shop.ModelController;
using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop_Shop.Areas.Admin.Controllers
{
    public class CartController : BaseController
    {
        private DBLaptopEntities db = new DBLaptopEntities();
        // GET: Admin/Cart
        public ActionResult Index()
        {
            List<Cart> crt = db.getListCart().ToList<Cart>();
            return View(crt);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.id_product = new SelectList(db.Products, "ID", "productName");
            ViewBag.id_user = new SelectList(db.Customers, "idUser", "accountName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cart crt)
        {
            try
            {
                db.add_Cart(crt.id_user, crt.id_product, crt.count);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Thêm thất bại", "fail");
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id_user, int id_pro)
        {
            ViewBag.id_product = new SelectList(db.Products, "ID", "productName");
            ViewBag.id_user = new SelectList(db.Customers, "idUser", "accountName");
            Cart crt = db.Carts.Where(x => x.id_product == id_pro && x.id_user == id_user).FirstOrDefault();
            return View(crt);
        }
        [HttpPost]
        public ActionResult Edit(Cart crt)
        {
            try
            {
                if(crt.count > db.Products.Where(x => x.ID==crt.id_product).FirstOrDefault().viewCount || crt.count<0)
                {
                    SetAlert("Sửa thất bại", "fail");
                    return RedirectToAction("Index");
                }
                using(var _context =new DBLaptopEntities())
                {
                    _context.Carts.AddOrUpdate(crt);
                    _context.SaveChanges();
                }
                SetAlert("Sửa thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Sửa thất bại", "fail");
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id_user,int id_pro)
        {
            try 
            {
                db.del_Cart(id_user, id_pro);
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Sửa thất bại", "error");
                return RedirectToAction("Index");
            }
        }
    }
}