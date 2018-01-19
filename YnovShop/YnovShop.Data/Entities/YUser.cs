using System;
using System.Collections.Generic;

namespace YnovShop.Data.Entities
{
    public partial class YUser
    {
        public YUser()
        {
            YProductPurchase = new HashSet<YProductPurchase>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
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
