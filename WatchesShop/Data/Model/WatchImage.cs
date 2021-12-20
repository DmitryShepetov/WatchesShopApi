using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchesShop.Data.Model
{
    public class WatchImage
    {
        public int id { get; set; }
        public byte[] img { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
