using BusinessEntities;
using Common;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;


namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository userRepository)
        {
            _productRepository = userRepository;
        }

        public BusinessEntities.Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }
        
        public IEnumerable<BusinessEntities.Product> GetProducts()
        {
            return _productRepository.GetAll();
        }
        


    }
}
