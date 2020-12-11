using Laptop_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop_Shop.ModelController
{
    public class BrandController
    {
        public static List<Brand> ViewBrands()
        {
            using (var _context = new DBLaptopEntities())
            {
                var listViewBrands = _context.view_list_Brand.ToList();
                List<Brand> brand = new List<Brand>();
                foreach (var item in listViewBrands)
                {
                    brand.Add(new Brand { brandName = item.brandName, brandDescription = item.brandDescription, brandHomePage = item.brandHomePage, ID = item.ID });
                }
                return brand;
            }
        }
        public static bool AddBrands(string brandName, string brandDescription, string brandHomePage)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbAddCate = _context.Add_new_Brand(brandName, brandDescription, brandHomePage);
                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
        public static bool DeleteBrands(int id)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbAddCate = _context.del_Brands(id);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool get01cate(int id)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbget01cate = _context.get_a_Brands(id);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool EditBrands(int id, string brandName, string brandDescription, string brandHomePage)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbedit = _context.edit_Brands(id, brandName, brandDescription, brandHomePage);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<Brand> SearchBrands(string name)
        {
            using (var _context = new DBLaptopEntities())
            {
                var dbsearch = _context.search_Brand(name);
                List<Brand> brand = new List<Brand>();
                foreach (var item in dbsearch)
                {
                    brand.Add(new Brand { brandName = item.brandName, brandDescription = item.brandDescription, ID = item.ID });
                }
                return brand;
            }
        }
    }
}