using System;

namespace WebApi.Controllers
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityInStock { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? isAvailable { get; set; }
         
    }
}