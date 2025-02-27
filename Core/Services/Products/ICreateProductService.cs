using BusinessEntities;
using System;

namespace WebApi.Controllers
{
    public interface ICreateProductService
    {
       Product Create(Guid id, string productName, string description, decimal? price, int? quantity, bool? isavailable , DateTime? dateAdded);
    }
}