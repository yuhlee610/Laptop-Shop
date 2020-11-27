using LaptopShop.ModelController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopShop.Areas.Admin.Controllers
{
    public class ManageCustomersController : Controller
    {
        // GET: Admin/ManageCustomers
        public ActionResult Index(string searchString, int page = 1, int pageSize = 1)
        {
            var model = CustomerController.ListAllPaging(searchString, page, pageSize);
            ViewBag.Searching = searchString;
            return View(model);
        }
    }
}