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
     
        public IEnumerable<Order> Get( string userId = null,
                                                int? quantity = null,
                                                DateTime? orderDate = null,
                                                bool? isProcessed = null,
                                                List<string> productList = null
                                                )
        {
            var query = _documentSession.Advanced.DocumentQuery<Order, OrderListindex>();

            var hasFirstParameter = false;

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.WhereEquals("UserId", userId);
                hasFirstParameter = true;
            }

            if (isProcessed.HasValue)
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereEquals("IsProcessed", isProcessed.Value);
                hasFirstParameter = true;
            }

            if (orderDate.HasValue)
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereGreaterThanOrEqual("OrderDate", orderDate.Value);
                hasFirstParameter = true;
            }

            if (productList != null && productList.Any())
            {
                if (hasFirstParameter) query = query.AndAlso();
                query = query.WhereIn("Products", productList);
            }

            return query.ToList();
        }

    




        public void DeleteAll()
        {
            base.DeleteAll<OrderListindex>();
        }

    }
}
