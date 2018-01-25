﻿using System;
using System.Collections.Generic;

namespace YnovShop.Entities
{
    public partial class YProductPurchase
    {
        public int IdYuser { get; set; }
        public int IdYproduct { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public YProduct IdYproductNavigation { get; set; }
        public YUser IdYuserNavigation { get; set; }
    }
}
