﻿using Laptop_Shop.ModelController;
using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laptop_Shop.Areas.Admin.Controllers
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
            if(CustomerController.ValidEmail(cus.Email))
            {
                SetAlert("Email không hợp lệ", "fail");
                return View("Create");
            }
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer cus = new Customer();
            cus = CustomerController.ViewDetail(id);
            return View(cus);
        }
        [HttpPost]
        public ActionResult Edit(Customer cus)
        {
            CustomerController.EditCustomer(cus);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CustomerController.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}