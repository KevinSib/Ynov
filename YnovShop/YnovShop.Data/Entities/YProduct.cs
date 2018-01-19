using System;
using System.Collections.Generic;
using System.Text;

namespace YnovShop.Data.Entities
{
    class YProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public DateTime ReplenishmentDate { get; set; }
        }
}
