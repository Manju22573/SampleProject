using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
       void Update(Order order,  bool IsProcessed, DateTime? orderDate, int Quantity , IEnumerable<string> productIds, string UserId,decimal? totalPrice);

    }
}
