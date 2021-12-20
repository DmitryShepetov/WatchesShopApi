using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Repository;
using WatchesShopReborn.ViewModels;

namespace WatchesShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopCartController : Controller
    {
        private readonly ShopCartRepository shopCartRepository;
        private readonly IWatch watchRep;
        public ShopCartController(ShopCartRepository shopCartRepository, IWatch watchRep)
        {
            this.shopCartRepository = shopCartRepository;
            this.watchRep = watchRep;
        }
        // GET api/ShopCart/
        public ViewResult Cart()
        {
            var item = shopCartRepository.getShopItems;
            shopCartRepository.listShopItem = item;
            var obj = new ShopCartViewModel { shopCart = shopCartRepository };
            return View(obj);
        }
        // POST api/ShopCart/
        [HttpPost]
        public async Task<ActionResult> addToCart(int id)
        {
            var item = await watchRep.getObjectWatchAsync(id);
            if (item != null)
            {
                await shopCartRepository.AddToCart(item);
            }
            return Ok(item);
        }
    }
}
