using BusinessEntities;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusinessEntities;
    using Common;
    using global::Data.Indexes;
    using Raven.Client.Documents;
    using Raven.Client.Documents.Indexes;
    using Raven.Client.Documents.Session;
    using static System.Collections.Specialized.BitVector32;

    namespace Data.Repositories
    {
        [AutoRegister]
        public class ProductRepository : Repository<Product>, IProductRepository
        {
            private readonly IDocumentSession _documentSession;

            public ProductRepository(IDocumentSession documentSession) : base(documentSession)
            {
                _documentSession = documentSession;
            }

            public IEnumerable<Product> Get(string productName = null, string description = null, decimal? price = null, int? quantityInStock = null, DateTime? dateAdded = null, bool? isAvailable = null)
            {
                var query = _documentSession.Advanced.DocumentQuery<Product, ProductListIndex>();

                bool hasFirstParameter = false;

                if (!string.IsNullOrEmpty(productName))
                {
                    query = query.Search(x => x.ProductName, $"*{productName}*");
                    hasFirstParameter = true;
                }

                if (quantityInStock.HasValue)
                {
                    if (hasFirstParameter) query = query.AndAlso();
                    query = query.WhereEquals(x => x.QuantityInStock, quantityInStock.Value);
                    hasFirstParameter = true;
                }
                                
                if (isAvailable.HasValue)
                {
                    if (hasFirstParameter) query = query.AndAlso();
                    query = query.WhereEquals(x => x.IsAvailable, isAvailable.Value);
                }

                return query.ToList();
            }

            public void DeleteAll()
            {
                base.DeleteAll<ProductListIndex>();
            }

            public IEnumerable<Product> GetAll()
            {
                var products = _documentSession.Query<Product>().ToList();
                return products;
            }
        }
    }

}
