using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShopReborn.ViewModels
{
    public class WatchListViewModel
    {
        public IEnumerable<Watch> allWatch { get; set; }
        public IEnumerable<WatchImage> watchImages { get; set; }
        public string currCategory { get; set; }
    }
}
