using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Common.Extensions;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private string _productName;
        private string _description;
        private decimal? _price;
        private int? _quantityInStock;
        private DateTime? _dateAdded;
        private bool? _isAvailable;

        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public decimal? Price
        {
            get => _price;
            private set => _price = value;
        }

        public int? QuantityInStock
        {
            get => _quantityInStock;
            private set => _quantityInStock = value;
        }

        public DateTime? DateAdded
        {
            get => _dateAdded;
            private set => _dateAdded = value;
        }

        public bool? IsAvailable
        {
            get => _isAvailable;
            private set => _isAvailable = value;
        }

        public void SetProductName(string category)
        {
           this.ProductName = category;
        }

        public void SetDescription(string description)
        {
            this.Description = description;
        }

        public void SetPrice(decimal? price)
        {
            this._price = price;
        }

        public void SetQuantityinStock(int? quantityInStock)
        {
            this._quantityInStock = quantityInStock;            
            
        }
        public void SetisAvailable(bool? isAvailable)
        {

            this.IsAvailable = isAvailable;
        }
        public void SetDateAdded(DateTime? dateAdded)
        {

            this.DateAdded = dateAdded;
        }
    }
}
