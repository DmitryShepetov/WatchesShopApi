using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class WatchRepository : IWatch
    {
        private readonly AppDBContext appDBContext;
        public WatchRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task<List<Watch>> AllWatch() => await appDBContext.Watch.Include(c => c.Category).ToListAsync();
        public async Task<List<Watch>> getFavWatch() => await appDBContext.Watch.Where(p => p.isFavourite).Include(c => c.Category).ToListAsync();
        public async Task<List<Watch>> getCategoryWatch(string category) => await appDBContext.Watch.Where(p => p.Category.categoryName == category).ToListAsync();
        public async Task<List<Watch>> getWatchInfo(string? category, string? type, string? name)
        {
            List<Watch> watches = new List<Watch>();
            watches = await appDBContext.Watch.Include(c => c.Category).ToListAsync();
            if (name != null)
                watches = await appDBContext.Watch.Where(p => p.name == name).ToListAsync();
            if(type != null)
                watches = await appDBContext.Watch.Where(p => p.type == type).ToListAsync();
            if(category != null)
                watches = await appDBContext.Watch.Where(p => p.Category.categoryName == category).ToListAsync();
            return watches;
        }
        public async Task<List<Watch>> getTypeWatch(string type) => await appDBContext.Watch.Where(p => p.type == type).ToListAsync();
        public async Task<List<Watch>> getNewWatch() => await appDBContext.Watch.Where(p => p.newWatch).ToListAsync();
        public async Task<List<Watch>> getSortWatch(int category) => await appDBContext.Watch.Where(p => p.Category.id == category).Include(c => c.Category).ToListAsync();
        public async Task<Watch> getObjectWatchAsync(int watchId) => await appDBContext.Watch.FirstOrDefaultAsync(p => p.id == watchId);
    }
}
