using BusinessEntities;
using System.Collections.Generic;
using System;

namespace WebApi.Controllers
{
    public interface IGetOrderService 
    {
        Order GetOrder(Guid id);

        IEnumerable<Order> GetOrders(string productId = null, string userId=null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null);

       
    }
}