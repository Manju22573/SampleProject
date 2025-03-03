using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    public class OrderModel
    {
        [Required(ErrorMessage = "ProductIds is required")]
        public IEnumerable<string> ProductIds { get;  set; }
        public int Quantity { get;  set; }
        public decimal? TotalPrice { get;  set; }
        public DateTime? OrderDate { get;  set; }
        public bool IsProcessed { get;  set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

    }
}