using LaptopShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopShop.ModelController
{
    public class CustomerController
    {
        public static IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            using (var _context=new DBLaptopEntities())
            {
                IQueryable<Customer> model = _context.Customers;
                if (!string.IsNullOrEmpty(searchString))
                {
                    model = model.Where(x => x.accountName.Contains(searchString)
                        || x.accountName.Contains(searchString));
                }
                return model.OrderByDescending(x => x.accountName).ToPagedList(page, pageSize);
            }
            
        }
    }
}