﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laptop_Shop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBLaptopEntities : DbContext
    {
        public DBLaptopEntities()
            : base("name=DBLaptopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<cusAuthe> cusAuthes { get; set; }
        public virtual DbSet<cusAuthe_Roles> cusAuthe_Roles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<view_list_Category> view_list_Category { get; set; }
        public virtual DbSet<view_list_Brand> view_list_Brand { get; set; }
    
        public virtual int C_Customers(string accountName, string passWord, Nullable<int> idCusAuthe, string firstName, string lastName, Nullable<bool> sex, string address, string phoneNumber, string email, Nullable<System.DateTime> dateRegistation, Nullable<System.DateTime> dateActivated)
        {
            var accountNameParameter = accountName != null ?
                new ObjectParameter("accountName", accountName) :
                new ObjectParameter("accountName", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("passWord", passWord) :
                new ObjectParameter("passWord", typeof(string));
    
            var idCusAutheParameter = idCusAuthe.HasValue ?
                new ObjectParameter("idCusAuthe", idCusAuthe) :
                new ObjectParameter("idCusAuthe", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("Sex", sex) :
                new ObjectParameter("Sex", typeof(bool));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("phoneNumber", phoneNumber) :
                new ObjectParameter("phoneNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dateRegistationParameter = dateRegistation.HasValue ?
                new ObjectParameter("dateRegistation", dateRegistation) :
                new ObjectParameter("dateRegistation", typeof(System.DateTime));
    
            var dateActivatedParameter = dateActivated.HasValue ?
                new ObjectParameter("dateActivated", dateActivated) :
                new ObjectParameter("dateActivated", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("C_Customers", accountNameParameter, passWordParameter, idCusAutheParameter, firstNameParameter, lastNameParameter, sexParameter, addressParameter, phoneNumberParameter, emailParameter, dateRegistationParameter, dateActivatedParameter);
        }
    
        public virtual int Delete_Customer(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Delete_Customer", idUserParameter);
        }
    
        [DbFunction("DBLaptopEntities", "F_getCustomerByID")]
        public virtual IQueryable<Customer> F_getCustomerByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Customer>("[DBLaptopEntities].[F_getCustomerByID](@id)", idParameter);
        }
    
        public virtual int Update_Customers(Nullable<int> idUser, string accountName, string passWord, Nullable<int> idCusAuthe, string firstName, string lastName, Nullable<bool> sex, string address, string phoneNumber, string email, Nullable<System.DateTime> dateRegistation, Nullable<System.DateTime> dateActivated)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("idUser", idUser) :
                new ObjectParameter("idUser", typeof(int));
    
            var accountNameParameter = accountName != null ?
                new ObjectParameter("accountName", accountName) :
                new ObjectParameter("accountName", typeof(string));
    
            var passWordParameter = passWord != null ?
                new ObjectParameter("passWord", passWord) :
                new ObjectParameter("passWord", typeof(string));
    
            var idCusAutheParameter = idCusAuthe.HasValue ?
                new ObjectParameter("idCusAuthe", idCusAuthe) :
                new ObjectParameter("idCusAuthe", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("Sex", sex) :
                new ObjectParameter("Sex", typeof(bool));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var phoneNumberParameter = phoneNumber != null ?
                new ObjectParameter("phoneNumber", phoneNumber) :
                new ObjectParameter("phoneNumber", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var dateRegistationParameter = dateRegistation.HasValue ?
                new ObjectParameter("dateRegistation", dateRegistation) :
                new ObjectParameter("dateRegistation", typeof(System.DateTime));
    
            var dateActivatedParameter = dateActivated.HasValue ?
                new ObjectParameter("dateActivated", dateActivated) :
                new ObjectParameter("dateActivated", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_Customers", idUserParameter, accountNameParameter, passWordParameter, idCusAutheParameter, firstNameParameter, lastNameParameter, sexParameter, addressParameter, phoneNumberParameter, emailParameter, dateRegistationParameter, dateActivatedParameter);
        }
    
        public virtual int Add_new_Cate(string cateName, string cateDescription)
        {
            var cateNameParameter = cateName != null ?
                new ObjectParameter("cateName", cateName) :
                new ObjectParameter("cateName", typeof(string));
    
            var cateDescriptionParameter = cateDescription != null ?
                new ObjectParameter("cateDescription", cateDescription) :
                new ObjectParameter("cateDescription", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_new_Cate", cateNameParameter, cateDescriptionParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int sp_alterdiagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram1(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram1", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams1_Result> sp_helpdiagrams1(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams1_Result>("sp_helpdiagrams1", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_upgraddiagrams1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams1");
        }
    
        public virtual int del_cate(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("del_cate", idParameter);
        }
    
        public virtual int edit_cate(Nullable<int> id, string nameCate, string desCate)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameCateParameter = nameCate != null ?
                new ObjectParameter("nameCate", nameCate) :
                new ObjectParameter("nameCate", typeof(string));
    
            var desCateParameter = desCate != null ?
                new ObjectParameter("desCate", desCate) :
                new ObjectParameter("desCate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("edit_cate", idParameter, nameCateParameter, desCateParameter);
        }
    
        public virtual ObjectResult<get_a_cate_Result> get_a_cate(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_a_cate_Result>("get_a_cate", idParameter);
        }
    
        public virtual ObjectResult<search_Cate_Result1> search_Cate(string namecate)
        {
            var namecateParameter = namecate != null ?
                new ObjectParameter("namecate", namecate) :
                new ObjectParameter("namecate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<search_Cate_Result1>("search_Cate", namecateParameter);
        }
    
        public virtual int Add_new_Brand(string brandName, string brandDescription, string brandHomePage)
        {
            var brandNameParameter = brandName != null ?
                new ObjectParameter("brandName", brandName) :
                new ObjectParameter("brandName", typeof(string));
    
            var brandDescriptionParameter = brandDescription != null ?
                new ObjectParameter("brandDescription", brandDescription) :
                new ObjectParameter("brandDescription", typeof(string));
    
            var brandHomePageParameter = brandHomePage != null ?
                new ObjectParameter("brandHomePage", brandHomePage) :
                new ObjectParameter("brandHomePage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Add_new_Brand", brandNameParameter, brandDescriptionParameter, brandHomePageParameter);
        }
    
        public virtual int del_Brands(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("del_Brands", idParameter);
        }
    
        public virtual int edit_Brands(Nullable<int> id, string brandName, string brandDescription, string brandHomePage)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var brandNameParameter = brandName != null ?
                new ObjectParameter("brandName", brandName) :
                new ObjectParameter("brandName", typeof(string));
    
            var brandDescriptionParameter = brandDescription != null ?
                new ObjectParameter("brandDescription", brandDescription) :
                new ObjectParameter("brandDescription", typeof(string));
    
            var brandHomePageParameter = brandHomePage != null ?
                new ObjectParameter("brandHomePage", brandHomePage) :
                new ObjectParameter("brandHomePage", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("edit_Brands", idParameter, brandNameParameter, brandDescriptionParameter, brandHomePageParameter);
        }
    
        public virtual ObjectResult<get_a_Brands_Result> get_a_Brands(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_a_Brands_Result>("get_a_Brands", idParameter);
        }
    
        public virtual ObjectResult<search_Brand_Result> search_Brand(string brandName)
        {
            var brandNameParameter = brandName != null ?
                new ObjectParameter("brandName", brandName) :
                new ObjectParameter("brandName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<search_Brand_Result>("search_Brand", brandNameParameter);
        }
    
        public virtual ObjectResult<Product> get_a_Product(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("get_a_Product", idParameter);
        }
    
        public virtual ObjectResult<Product> get_a_Product(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Product>("get_a_Product", mergeOption, idParameter);
        }
    
        public virtual int add_Cart(Nullable<int> id_user, Nullable<int> id_pro, Nullable<int> count)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(int));
    
            var id_proParameter = id_pro.HasValue ?
                new ObjectParameter("id_pro", id_pro) :
                new ObjectParameter("id_pro", typeof(int));
    
            var countParameter = count.HasValue ?
                new ObjectParameter("count", count) :
                new ObjectParameter("count", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("add_Cart", id_userParameter, id_proParameter, countParameter);
        }
    
        [DbFunction("DBLaptopEntities", "F_getBrandByID")]
        public virtual IQueryable<Brand> F_getBrandByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Brand>("[DBLaptopEntities].[F_getBrandByID](@id)", idParameter);
        }
    
        [DbFunction("DBLaptopEntities", "F_getCategoryByID")]
        public virtual IQueryable<Category> F_getCategoryByID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Category>("[DBLaptopEntities].[F_getCategoryByID](@id)", idParameter);
        }
    
        [DbFunction("DBLaptopEntities", "getCart")]
        public virtual IQueryable<getCart_Result> getCart(Nullable<int> id_user)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<getCart_Result>("[DBLaptopEntities].[getCart](@id_user)", id_userParameter);
        }
    
        public virtual int del_Cart(Nullable<int> id_user, Nullable<int> id_pro)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(int));
    
            var id_proParameter = id_pro.HasValue ?
                new ObjectParameter("id_pro", id_pro) :
                new ObjectParameter("id_pro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("del_Cart", id_userParameter, id_proParameter);
        }
    
        public virtual int Charge(Nullable<int> id_user, Nullable<int> id_pro)
        {
            var id_userParameter = id_user.HasValue ?
                new ObjectParameter("id_user", id_user) :
                new ObjectParameter("id_user", typeof(int));
    
            var id_proParameter = id_pro.HasValue ?
                new ObjectParameter("id_pro", id_pro) :
                new ObjectParameter("id_pro", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Charge", id_userParameter, id_proParameter);
        }
    
        [DbFunction("DBLaptopEntities", "getListCart")]
        public virtual IQueryable<Cart> getListCart()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Cart>("[DBLaptopEntities].[getListCart]()");
        }
    }
}
