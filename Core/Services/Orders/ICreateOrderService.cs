using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order Create(Guid id, bool IsProcessed, DateTime? orderDate, int Quantity, string productId, string UserId , decimal? totalPrice);


    }
}
