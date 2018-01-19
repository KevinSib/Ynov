using System;
using System.Collections.Generic;
using System.Text;

namespace YnovShop.Data.Entities
{
    class YProductPurchase
    {
        public YUser YUser { get; set; }
        public YProduct YProduct { get; set; }
        public DateTime PurchaseDate { get; set; }
    }

}
