using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContext appDBContext;
        private readonly ShopCartRepository shopCartRepository;
        public OrdersRepository(AppDBContext appDBContext, ShopCartRepository shopCartRepository)
        {
            this.appDBContext = appDBContext;
            this.shopCartRepository = shopCartRepository;
        }
        public async void createOrderAsync(Order order)
        {
            order.dateTime = DateTime.Now;
            await appDBContext.Order.AddAsync(order);
            await appDBContext.SaveChangesAsync();
            var items = shopCartRepository.listShopItem;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    watchId = el.watch.id,
                    orderId = order.id,
                    price = el.watch.price
                };
                await appDBContext.OrderDetails.AddAsync(orderDetail);
            }
            await appDBContext.SaveChangesAsync();
        }
    }
}
