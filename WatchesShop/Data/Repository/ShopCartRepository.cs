using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class ShopCartRepository
    {
        public readonly AppDBContext appDBContext;
        public ShopCartRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public List<ShopCartItem> listShopItem { get; set; }
        public string ShopCartId { get; set; }
        public static ShopCartRepository GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CarId", shopCartId);
            return new ShopCartRepository(context) { ShopCartId = shopCartId };
        }
        public async Task AddToCart(Watch watch)
        {
            await appDBContext.ShopCartItems.AddAsync(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                watch = watch,
                price = watch.price
            });
            await appDBContext.SaveChangesAsync();
        }
        public List<ShopCartItem> getShopItems => appDBContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.watch).ToList();
    }
}
