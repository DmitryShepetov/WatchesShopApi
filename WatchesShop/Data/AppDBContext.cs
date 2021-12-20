using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
             
        }
        public DbSet<Watch> Watch { get; set; }
        public DbSet<WatchImage> WatchImage { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
