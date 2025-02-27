using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class DeleteOrderService : IDeleteOrderService
    {   
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Delete(BusinessEntities.Order order)
        {
            _orderRepository.Delete(order);
        }

        public void DeleteAll()
        {
            _orderRepository.DeleteAll();
        }

    }
}
