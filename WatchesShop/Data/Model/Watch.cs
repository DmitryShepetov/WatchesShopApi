using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WatchesShop.Data.Model
{
    public class Watch
    {
        public int id { set; get; }
        public string type { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public ushort price { set; get; }
        public bool isFavourite { set; get; }
        public string img { set; get; }
        public bool newWatch { get; set; }
        public bool available { set; get; }
        public Category Category { set; get; }
        public List<WatchImage> WatchImage { get; set; }
    }
}
