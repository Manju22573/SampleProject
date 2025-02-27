using BusinessEntities;
using System;

namespace WebApi.Controllers
{
    public interface IUpdateProductService
    {
        void Update(Product product, string productName, string description, decimal? price, int? quantity, bool? isavailable , DateTime? dateAdded );
    }
}