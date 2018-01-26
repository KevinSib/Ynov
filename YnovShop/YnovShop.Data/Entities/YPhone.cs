using System.Collections.Generic;

namespace YnovShop.Data.Entities
{
    
    public partial class YPhone
    {
        public YPhone()
        {
            YUser = new HashSet<YUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public ICollection<YUser> YUser { get; set; }
    }
}
