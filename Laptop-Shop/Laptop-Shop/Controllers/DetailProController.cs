using Laptop_Shop.ModelController;
using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Laptop_Shop.Controllers
{
    public class DetailProController : Controller
    {
        // GET: DetailPro
        private DBLaptopEntities db = new DBLaptopEntities();
        //xem chi tiết sản phẩm
        public ActionResult Index(int id)
        {
            Product pro = DetailPro.GetProduct(id);
            Category cate = DetailPro.getDataCategory(pro.categoryID.Value);
            Brand br = DetailPro.getDataBrand(pro.BrandID.Value);
            ViewBag.cate = cate;
            ViewBag.brand = br;
            return View(pro);
        }
        //thêm vào giỏ hàng
        public ActionResult AddtoCart(int id_pro, int count)
        {
            Customer cus = Session["customer"] as Customer;
            db.add_Cart(3, id_pro, count);
            return Content("success");
        }
        //Hiển thị sản phẩm trong giỏ hàng
        public ActionResult Cart()
        {
            Customer cus = Session["customer"] as Customer;
            if (cus != null)
            {
                //Lấy giỏ hàng của user đăng nhập
                var listCart = db.getCart(cus.idUser);
                ViewBag.listCart = listCart;
                ViewBag.count = listCart.Count();
            }
            else
            {
                //Không đăng nhập thì giỏ hàng rỗng
                var listCart = db.getCart(3);
                ViewBag.listCart = listCart;
            }
            return View();
        }
        public ActionResult DeleteItem(int id_pro)
        {
            Customer cus = Session["customer"] as Customer;
            db.del_Cart(3, id_pro);
            return Content("");
        }
        public ActionResult Charge()
        {
            Customer cus = Session["customer"] as Customer;
            //if (cus == null)
            //{
            //    //toi trang dap nhap
            //    return RedirectToAction("Index",new {id = 1 });
            //}
            var listCart = db.getCart(3);
            decimal tong = 0;
            string prodName = "";
            foreach(var item in listCart)
            {
                prodName = prodName  + item.productName +" số lượng : "+item.count+ "\n";
                tong = tong + (decimal)item.Price * (int)item.count;
            }
            //email của dự án
            string email = "nhomltweb@gmail.com";
            string password = "123456789a@";

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);


            msg.From = new MailAddress(email);
            //msg.To.Add(cus.Email);
            msg.To.Add("letranduchuy41@gmail.com");
            msg.Subject = "Xác nhận thanh toán";
            msg.Body = "Cảm ơn quý khác đã mua sản phẩm của chúng tôi. Tổng số tiền thanh toán là "+tong+
                ". Danh sách sản phẩm gồm:\n"+prodName;
            msg.IsBodyHtml = true;

            //gán cho biến TempData để có thể kiểm tra xem user nhập đúng không 

            //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25))
            //{
            //    smtp.Credentials = loginInfo;
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = false;
            //    smtp.Send(msg);
            //}
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            using(var _context=new DBLaptopEntities())
            {
                foreach(var item in listCart)
                {
                    _context.Charge(3, item.id_product);
                }
                _context.SaveChanges();
            }
            ////Xoa san pham trong gio hang
            //foreach(var item in listCart)
            //{
            //    //db.Charge(item.id_product, cus.idUser);
            //    db.Charge(3, item.id_product);
            //    db.SaveChanges();
            //}

            return RedirectToAction("Index",new { id = 1 });
        }
    }
}