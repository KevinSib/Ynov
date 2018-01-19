using System;
using Microsoft.EntityFrameworkCore;
using YnovShop.Data.Entities;

namespace YnovShop.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<YUser> Users { get; set; }
    }
}
