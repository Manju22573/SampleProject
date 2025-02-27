using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> Get(string productId = null, string userId =null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null  );
         void DeleteAll();
        

    }
}
