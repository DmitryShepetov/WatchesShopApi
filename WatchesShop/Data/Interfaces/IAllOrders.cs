using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrderAsync(Order order);
    }
}
