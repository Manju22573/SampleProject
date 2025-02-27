
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models.Order
{
    public class Order
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsProcessed { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
    }

}