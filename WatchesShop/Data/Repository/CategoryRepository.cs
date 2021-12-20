using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class CategoryRepository : IWatchCategory
    {
        private readonly AppDBContext appDBContext;
        public CategoryRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Category> AllCategories => appDBContext.Category;
        
    }
}
