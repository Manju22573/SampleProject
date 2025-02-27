using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;
using Core.Factories;
using Common;


namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {

        private readonly IUpdateProductService _updateProductService;
        private readonly IIdObjectFactory<BusinessEntities.Product> _productFactory;
        private readonly IProductRepository _productRepository;

        public CreateProductService(IIdObjectFactory<BusinessEntities.Product> productFactory, IProductRepository productRepository, IUpdateProductService updateProductService)
        {
            _productFactory = productFactory;
            _productRepository = productRepository;
            _updateProductService = updateProductService;
        }

        public BusinessEntities.Product Create(Guid id, string productName, string description, decimal? price, int? quantity, bool? isavailable , DateTime? dateAdded)
        {
            var product = _productFactory.Create(id.ToString());
            _updateProductService.Update(product, productName, description, price, quantity, isavailable , dateAdded);
            _productRepository.Save(product);
            return product;
        }
    }
}
