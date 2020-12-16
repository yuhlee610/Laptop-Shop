using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop_Shop.ModelController
{
    public class DetailPro
    {
        public static Product GetProduct(int id)
        {
            using (var _context=new DBLaptopEntities())
            {
                return _context.get_a_Product(id).FirstOrDefault();
            }
        }
        public static Category getDataCategory(int id)
        {
            using(var _context=new DBLaptopEntities())
            {
                return _context.F_getCategoryByID(id).FirstOrDefault();
            }
        }
        public static Brand getDataBrand(int id)
        {
            using(var _context=new DBLaptopEntities())
            {
                return _context.F_getBrandByID(id).FirstOrDefault();
            }
        }
    }
}