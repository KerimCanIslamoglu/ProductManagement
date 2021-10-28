using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.DataAccess.Context
{
   public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=ProductManagementDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasIndex(x => x.ProductCode)
                .IsUnique();

            modelBuilder.Entity<Campaign>()
               .HasIndex(x => x.CampaignName)
               .IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne<Product>(e => e.Product)
                .WithMany(c => c.Orders)
                .HasForeignKey(s=>s.ProductId);

            modelBuilder.Entity<Campaign>()
             .HasOne<Product>(e => e.Product)
             .WithMany(c => c.Campaigns)
             .HasForeignKey(s => s.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
    }
}
