using Microsoft.EntityFrameworkCore;

namespace YnovShop.Data.Entities
{
    public partial class YnovShopContext : DbContext
    {
       
        public virtual DbSet<YAddress> YAddress { get; set; }
        public virtual DbSet<YPhone> YPhone { get; set; }
        public virtual DbSet<YProduct> YProduct { get; set; }
        public virtual DbSet<YProductPurchase> YProductPurchase { get; set; }
        public virtual DbSet<YUser> YUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=nsb.heavydev.fr;Database=YnovShop;User ID=sa;Password=ynov2018ks");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<YAddress>(entity =>
            {
                entity.ToTable("Y_Address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodePostal)
                    .HasColumnName("code_postal")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.Road)
                    .HasColumnName("road")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YPhone>(entity =>
            {
                entity.ToTable("Y_Phone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YProduct>(entity =>
            {
                entity.ToTable("Y_Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descritption)
                    .HasColumnName("descritption")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ReplenishmentDate)
                    .HasColumnName("replenishmentDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<YProductPurchase>(entity =>
            {
                entity.ToTable("Y_Product_Purchase");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdYproduct).HasColumnName("id_yproduct");

                entity.Property(e => e.IdYuser).HasColumnName("id_yuser");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchaseDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdYproductNavigation)
                    .WithMany(p => p.YProductPurchase)
                    .HasForeignKey(d => d.IdYproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productproductpurchase");

                entity.HasOne(d => d.IdYuserNavigation)
                    .WithMany(p => p.YProductPurchase)
                    .HasForeignKey(d => d.IdYuser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userproductpurchase");
            });

            modelBuilder.Entity<YUser>(entity =>
            {
                entity.ToTable("Y_User");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Y_User__AB6E616410C1C9B6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdYaddress).HasColumnName("id_yaddress");

                entity.Property(e => e.IdYphone).HasColumnName("id_yphone");

                entity.Property(e => e.IsEnable).HasColumnName("isEnable");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasColumnName("passwordHash")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Registration)
                    .HasColumnName("registration")
                    .HasColumnType("datetime");

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
