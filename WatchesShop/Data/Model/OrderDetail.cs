using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchesShop.Data.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int watchId { get; set; }
        public uint price { get; set; }
        public virtual Watch watch { get; set; }
        public virtual Order order { get; set; }
    }
}
