using LaptopShop.ModelController;
using LaptopShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ManageCustomersController : BaseController
    {
        // GET: Admin/ManageCustomers
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var model = CustomerController.ListAllPaging(searchString, page, pageSize);
            ViewBag.Searching = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            string encryptPass = Encrypt.GetMD5(cus.passWord);
            cus.passWord = encryptPass;
            if (CustomerController.CreateCustomer(cus))
            {
                SetAlert("Thêm User thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Thêm User thất bại", "fail");
                return RedirectToAction("Index");
            }
        }
    }
}