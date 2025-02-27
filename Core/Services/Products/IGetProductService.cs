using BusinessEntities;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    public interface IGetProductService
    {
        Product GetProduct(Guid productId);
        IEnumerable<Product> GetProducts();
    }
}

