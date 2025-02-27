using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Controllers;

namespace Core.Services.Product
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService :IUpdateProductService
    {

        public void Update(BusinessEntities.Product product, string productName, string description, decimal? price,int? quantity ,bool? isavailable, DateTime? dateAdded)
        {
            product.SetProductName(productName);
            product.SetDescription(description);
            product.SetPrice(price);
            product.SetQuantityinStock(quantity);
            product.SetisAvailable(isavailable);
            product.SetDateAdded(dateAdded);
        }

    }
}
