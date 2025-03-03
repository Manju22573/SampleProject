using BusinessEntities;
using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Indexes
{
    public class OrderListindex : AbstractIndexCreationTask<Order>
    {
        public OrderListindex()
        {
            Map = orders => from order in orders
                            select new
                            {
                                order.Id,
                                order.Products,
                                order.Quantity,
                                order.IsProcessed,

                            };

            Index(x => x.TotalPrice, FieldIndexing.No);
        }
    }


}
