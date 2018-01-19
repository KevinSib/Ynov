using System;
using System.Collections.Generic;

namespace YnovShop.Data.Entities
{
    public partial class YUser
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime Registration { get; set; }
        public bool IsEnable { get; set; }
        public YAddress YAddress { get; set; }
        public YPhone YPhone { get; set; }
    }
}
