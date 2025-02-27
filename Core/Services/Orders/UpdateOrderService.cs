using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateOrderService :IUpdateOrderService
    {        
        public void Update(Order order,  bool IsProcessed, DateTime? orderDate, int Quantity , string productId , string UserId , decimal? totalprice)
        {
            order.SetProductId(productId);
            order.SetIsProcessed(IsProcessed);
            order.SetOrderDate(orderDate);
            order.SetQuantity(Quantity);
            order.SetTotalPrice(totalprice);
            order.SetUserId(UserId);
         }
    }
}
