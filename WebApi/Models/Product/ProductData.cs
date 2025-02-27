
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.UI;
using System.Xml.Linq;
using BusinessEntities;


namespace WebApi.Models.Product
{
    public class ProductData : IdObjectData
    {

        public ProductData(BusinessEntities.Product product) : base(product)
        {
            ProductName = product.ProductName;  
            Description = product.Description;
            Price = product.Price;
            isAvailable = product.IsAvailable;
            QuantityInStock = product.QuantityInStock;                     
         
        }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? isAvailable { get; set; }
    }
}