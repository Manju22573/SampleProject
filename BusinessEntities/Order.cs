using System;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        private string _productId;
        private string _userId;
        private int _quantity;
        private decimal? _totalPrice;
        private DateTime? _orderDate;
        private bool _isProcessed;
  

        public string ProductId
        {
            get => _productId;
             set => _productId = value;
        }

        public string UserId
        {
            get => _userId;
             set => _userId = value;
        }

        public int Quantity
        {
            get => _quantity;
             set => _quantity = value;
        }

        public decimal? TotalPrice
        {
            get => _totalPrice;
             set => _totalPrice = value;
        }

        public DateTime? OrderDate
        {
            get => _orderDate;
             set => _orderDate = value;
        }

        public bool IsProcessed
        {
            get => _isProcessed;
             set => _isProcessed = value;
        }

    

        public void SetProductId(string productId)
        {
            ProductId = productId;
        }

        public void SetUserId(string userId)
        {
            UserId = userId;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void SetTotalPrice(decimal? totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public void SetOrderDate(DateTime? orderDate)
        {
            OrderDate = orderDate;
        }

        public void SetIsProcessed(bool isProcessed)
        {
            IsProcessed = isProcessed;
        }

   
    
    }
}
