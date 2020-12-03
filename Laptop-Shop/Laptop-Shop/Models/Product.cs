//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDatails = new HashSet<OrderDatail>();
        }
    
        public int ID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> promotionPrice { get; set; }
        public string productPicture { get; set; }
        public Nullable<int> categoryID { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> viewCount { get; set; }
        public Nullable<bool> productStatus { get; set; }
        public Nullable<int> BrandID { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDatail> OrderDatails { get; set; }
    }
}