using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;
using Sparrow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        
        private readonly IIdObjectFactory<Order> _orderFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IUpdateOrderService _updateOrderService;

        public CreateOrderService(IIdObjectFactory<Order> OrderFactory, IOrderRepository OrderRepository, IUpdateOrderService updateOrderService)
        {
            _orderFactory = OrderFactory;
            _orderRepository = OrderRepository;
            _updateOrderService = updateOrderService;
        }

        public Order Create(Guid id,  bool IsProcessed, DateTime? orderDate, int Quantity, string productId, string UserId, decimal? totalPrice)
        {
            var order = _orderFactory.Create(id.ToString());
            _updateOrderService.Update(order,IsProcessed,orderDate,Quantity,productId ,UserId,totalPrice);
            _orderRepository.Save(order);
            return order;
        }



    }
}
