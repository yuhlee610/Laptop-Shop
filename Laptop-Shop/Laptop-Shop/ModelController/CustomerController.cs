using Laptop_Shop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laptop_Shop.ModelController
{
    public class CustomerController
    {
        public static IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            using (var _context = new DBLaptopEntities())
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
        public static bool CreateCustomer(Customer cus)
        {
            using (var _context=new DBLaptopEntities())
            {
                var dbcust = (from c in _context.Customers
                              where c.accountName == cus.accountName
                              select c).SingleOrDefault();
                if (dbcust == null)
                {
                    _context.C_Customers(
                   cus.accountName,
                   cus.passWord,
                   cus.FirstName,
                   cus.LastName,
                   cus.Sex,
                   cus.Address,
                   cus.phoneNumber,
                   cus.Email,
                   cus.dateRegistation,
                   cus.dateActivated,
                   cus.Decentralization,
                   cus.Active);
                    return true;
                }
                else
                    return false;
            }
        }

        public static Customer ViewDetail(int id)
        {
            using(var _context = new DBLaptopEntities())
            {
                var dbcus = _context.F_getCustomerByID(id).ToList<Customer>();
                var cus = dbcus.FirstOrDefault();
                return cus;
            }
        }
        public static void EditCustomer(Customer cus)
        {
            using (var _context = new DBLaptopEntities())
            {
                _context.Update_Customers(cus.id, cus.accountName, cus.passWord, cus.FirstName, cus.LastName,
                    cus.Sex, cus.Address, cus.phoneNumber, cus.Email,
                    cus.dateRegistation, cus.dateActivated, cus.Decentralization, cus.Active);
            }
        }
        public static void DeleteCustomer(int id)
        {
            using(var _context = new DBLaptopEntities())
            {
                _context.Delete_Customer(id);
            }
        }
    }
}