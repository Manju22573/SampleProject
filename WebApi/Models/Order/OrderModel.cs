using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    public class OrderModel
    {
        [Required(ErrorMessage = "ProductId is required")]
        public string ProductId { get;  set; }
        public int Quantity { get;  set; }
        public decimal? TotalPrice { get;  set; }
        public DateTime? OrderDate { get;  set; }
        public bool IsProcessed { get;  set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

    }
}