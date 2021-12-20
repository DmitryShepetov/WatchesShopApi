using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Interfaces
{
    public interface IWatchCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
