using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> Get(string userId = null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null, List<string> productList =null);
         void DeleteAll();
        

    }
}
