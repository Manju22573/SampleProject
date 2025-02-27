using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> Get(string productName = null, string description = null, decimal? price = null, int? quantityInStock = null, DateTime? dateAdded = null, bool? isAvailable = null);
        IEnumerable<Product> GetAll();
       
        void DeleteAll();
    }
}


