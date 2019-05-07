using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IConsolidator.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string SellPrice { get; set; }
        public string CostPrice { get; set; }
    }
}