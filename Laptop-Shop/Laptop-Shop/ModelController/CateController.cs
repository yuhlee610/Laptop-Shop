using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laptop_Shop.Models;

namespace Laptop_Shop.ModelController
{
    public class CateController
    {
        public static List<Category> ViewCate()
        {
            using (var _context= new DBLaptopEntities())
            {
                var listviewCate = _context.view_list_Category.ToList();
                List<Category> categories = new List<Category>();
                foreach(var item in listviewCate)
                {
                    categories.Add(new Category { cateName=item.cateName, cateDescription=item.cateDescription, ID=item.ID});
                }
                return categories;
            }    
        }
        public static bool AddCate(string cateName, string cateDescription)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbAddCate = _context.Add_new_Cate(cateName, cateDescription);
                    return true;
                }
            }
            catch {
                return false;
            }
            
        }
        public static bool DelCate(int id)
        {
            try
            {
                using (var _context = new DBLaptopEntities())
                {
                    var dbAddCate = _context.del_cate(id);
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
                using (var _context= new DBLaptopEntities())
                {
                    var dbget01cate = _context.get_a_cate(id);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool EditCate(int id, string cateName, string cateDes)
        {
            try
            {
                using (var _context= new DBLaptopEntities())
                {
                    var dbedit = _context.edit_cate(id, cateName, cateDes);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static List<Category> searchCate(string name)
        {
            using (var _context = new DBLaptopEntities())
            {
                var dbsearch = _context.search_cate(name);
                List<Category> categories = new List<Category>();
                foreach (var item in dbsearch)
                {
                    categories.Add(new Category { cateName = item.cateName, cateDescription = item.cateDescription, ID = item.ID });
                }
                return categories;
            }
        }
    }
}