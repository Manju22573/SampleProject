using BusinessEntities;
using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Indexes
{
    public class ProductListIndex : AbstractIndexCreationTask<Product>
    {
        public ProductListIndex()
        {
            Map = products => from product in products
                              select new
                           {
                                  ProductName = product.ProductName ?? "Unknown",
                                  Price = product.Price ?? 0, // Handle null case
                                  IsAvailable = product.IsAvailable
                              };

            Index(x => x.Price, FieldIndexing.No);
        }
    }
}
