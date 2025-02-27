using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : Repository<Order> ,IOrderRepository
    {        
    
        private readonly IDocumentSession _documentSession;
        public OrderRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        //public IEnumerable<Order> Get(string productId = null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null)
        //{
        //    var query = _documentSession.Advanced.DocumentQuery<Order,OrderListindex>();

        //    bool hasFirstParameter = false;

        //    if (!string.IsNullOrEmpty(productId))
        //    {
        //        query = query.Search(x => x.ProductId, $"*{productId}*");
        //        hasFirstParameter = true;
        //    }

        //    if (quantity.HasValue)
        //    {
        //        if (hasFirstParameter) query = query.AndAlso();
        //        query = query.WhereEquals(x => x.Quantity, quantity.Value);
        //        hasFirstParameter = true;
        //    }

        //    if (orderDate.HasValue)
        //    {
        //        if (hasFirstParameter) query = query.AndAlso();
        //        query = query.WhereEquals(x => x.OrderDate, orderDate.Value);
        //        hasFirstParameter = true;
        //    }

        //    if (isProcessed.HasValue)
        //    {
        //        if (hasFirstParameter) query = query.AndAlso();
        //        query = query.WhereEquals(x => x.IsProcessed, isProcessed.Value);
        //    }

        //    return query.ToList();
        //}



        public IEnumerable<Order> Get(string productId = null, string userId = null, int? quantity = null, DateTime? orderDate = null, bool? isProcessed = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrderListindex>();

            bool hasFirstParameter = false;

            if (!string.IsNullOrEmpty(productId))
            {
                query = query.Search(x => x.ProductId, $"*{productId}*");
                hasFirstParameter = true;
            }

            if (quantity.HasValue)
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereEquals(x => x.Quantity, quantity.Value);
                hasFirstParameter = true;
            }

            if (orderDate.HasValue)
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereEquals(x => x.OrderDate, orderDate.Value);
                hasFirstParameter = true;
            }

            if (isProcessed.HasValue)
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereEquals(x => x.IsProcessed, isProcessed.Value);
                hasFirstParameter = true;
            }

            if (!string.IsNullOrEmpty(userId))
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereEquals(x => x.UserId, userId);
            }

           
            var orders = query
                .Include(x => x.ProductId)
                .Include(x => x.UserId)
                .ToList();

         
            var productIds = orders.Select(o => o.ProductId).Distinct();
            var userIds = orders.Select(o => o.UserId).Distinct();

            var products = _documentSession.Load<Product>(productIds);
            var users = _documentSession.Load<User>(userIds);

             var orderDetails = orders.Select(order => new Order
            {
                Id = order.Id,
                //UserName = !string.IsNullOrEmpty(order.UserId) && users.TryGetValue(order.UserId, out var user) ? user?.Name
                //// : "N/A",
                ////ProductName = !string.IsNullOrEmpty(order.ProductId) && products.TryGetValue(order.ProductId, out var product)
                //// ? product?.ProductName
                ////  : "N/A",
                ProductId = order.ProductId,
                UserId = order.UserId,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                IsProcessed = order.IsProcessed,
            
              
            }).ToList();

            return orderDetails;
        }


        public void DeleteAll()
        {
            base.DeleteAll<OrderListindex>();
        }

    }
}
