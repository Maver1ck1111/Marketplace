using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Entities
{
    public class ElectronDB : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public ElectronDB(DbContextOptions<ElectronDB> options) : base(options) { }


        public DbSet<Cart> Carts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<PaidOrder> PaidOrders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cart>()
                .ToTable("Carts")
                .HasKey(c => new { c.UserId, c.ProductId });

            builder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            builder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany()
                .HasForeignKey(c => c.ProductId);

            builder.Entity<Discount>()
                .ToTable("Discounts")
                .HasKey(d => d.Id);

            builder.Entity<Discount>()
                .HasOne(d => d.Product)
                .WithOne(p => p.Discount)
                .HasForeignKey<Discount>(d => d.ProductId);

            builder.Entity<PaidOrder>()
                .ToTable("PaidOrders")
                .HasKey(po => new { po.ProductId, po.DateTime });

            builder.Entity<PaidOrder>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId);

            builder.Entity<Product>()
                .ToTable("Products")
                .HasKey(p => p.Id);
        }
    }
}
