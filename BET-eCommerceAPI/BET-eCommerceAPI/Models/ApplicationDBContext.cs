using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BET_eCommerceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BET_eCommerceAPI.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<TbCategory> TbCategory { get; set; }
        public virtual DbSet<TbItem> TbItem { get; set; }
        public virtual DbSet<TbOrder> TbOrder { get; set; }
        public virtual DbSet<TbOrder_Item> TbOrder_item { get; set; }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        //Temporal Shopping
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Item> Order_Items { get; set; }
        public DbSet<Order_Tracking> Order_Trackings { get; set; }

        //Address Book
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Shipping_Address> Shipping_Addresses { get; set; }
        //
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}

