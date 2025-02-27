using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models.Order
{
    public class OrderData : IdObjectData
    {
        public OrderData(BusinessEntities.Order order) : base(order)
        {
            Id = order.Id;
            ProductId = order.ProductId;
            Quantity = order.Quantity;
            TotalPrice = order.TotalPrice;
            OrderDate = order.OrderDate;
            IsProcessed = order.IsProcessed;
            UserId = order.UserId;
            


        }
        
        public string UserId { get; private set; }
        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal? TotalPrice { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public bool IsProcessed { get; private set; }



    }
}
