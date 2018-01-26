using System;
using System.Collections.Generic;

namespace YnovShop.Entities
{
    public partial class YProduct
    {
        public YProduct()
        {
            YProductPurchase = new HashSet<YProductPurchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descritption { get; set; }
        public int? Stock { get; set; }
        public double? Price { get; set; }
        public DateTime? ReplenishmentDate { get; set; }

        public ICollection<YProductPurchase> YProductPurchase { get; set; }
    }
}
