using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;
using WatchesShop.Data.Repository;

namespace WatchesShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrdersRep;
        private readonly ShopCartRepository shopCartRep;
        public OrderController(IAllOrders allOrdersRep, ShopCartRepository shopCartRep)
        {
            this.allOrdersRep = allOrdersRep;
            this.shopCartRep = shopCartRep;
        }
        // POST api/Order/(ордер)
        [HttpPost]
        public ActionResult Order(Order order)
        {
            shopCartRep.listShopItem = shopCartRep.getShopItems;
            if (shopCartRep.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "Вы не выбрали товары!");
            }
            else if (ModelState.IsValid)
            {
                allOrdersRep.createOrderAsync(order);
                return Ok(order);
            }
            return BadRequest(order);
        }
    }
}
