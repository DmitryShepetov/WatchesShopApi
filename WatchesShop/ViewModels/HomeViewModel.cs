using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShopReborn.ViewModels
{
    public class HomeViewModel
    {
        public List<Watch> favWatch { get; set; }
        public List<Watch> getNewWatch { get; set; }
    }
}
