﻿using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderServices : IGetOrderService
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderServices(IOrderRepository userRepository)
        {
            _OrderRepository = userRepository;
        }

        public Order GetOrder(Guid id)
        {
            return _OrderRepository.Get(id);
        }
         

        public IEnumerable<Order> GetOrders(string productId = null, string userId = null,int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null)
        {
            return _OrderRepository.Get(productId,userId,quantity, orderDate, isProcessed);
        }
    }
}
