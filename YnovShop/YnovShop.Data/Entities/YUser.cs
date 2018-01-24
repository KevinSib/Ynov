﻿using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YnovShop.Data.Entities
{
    public partial class YUser : IdentityUser
    {
        public YUser()
        {
            YProductPurchase = new HashSet<YProductPurchase>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Salt { get; set; }
        public DateTime? Registration { get; set; }
        public bool? IsEnable { get; set; }
        public int IdYaddress { get; set; }
        public int IdYphone { get; set; }

        public YAddress IdYaddressNavigation { get; set; }
        public YPhone IdYphoneNavigation { get; set; }
        public ICollection<YProductPurchase> YProductPurchase { get; set; }
    }
}
