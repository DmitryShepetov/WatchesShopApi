using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchesShop.Data.Model
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Watch watch { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
