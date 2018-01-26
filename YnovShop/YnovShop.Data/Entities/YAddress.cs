using System.Collections.Generic;

namespace YnovShop.Data.Entities
{
    public partial class YAddress
    {
        public YAddress()
        {
            YUser = new HashSet<YUser>();
        }

        public int Id { get; set; }
        public string Road { get; set; }
        public string City { get; set; }
        public int? Floor { get; set; }
        public string CodePostal { get; set; }

        public ICollection<YUser> YUser { get; set; }
    }
}
