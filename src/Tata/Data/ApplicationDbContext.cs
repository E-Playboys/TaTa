using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tata.Models;
using Digipolis.DataAccess.Context;
using Tata.Entities;

namespace Tata.Data
{
    public class ApplicationDbContext : ApplicationEntityContextBase<ApplicationDbContext>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Billing> Billings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        //public DbSet<UserProduct> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class ApplicationEntityContextBase<TContext> : IdentityDbContext<ApplicationUser> where TContext : DbContext
    {
        public ApplicationEntityContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }
    }
}
