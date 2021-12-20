using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Interfaces
{
    public interface IWatch
    {
        Task<List<Watch>> AllWatch();
        Task<List<Watch>> getFavWatch();
        Task<List<Watch>> getCategoryWatch(string category);
        Task<List<Watch>> getTypeWatch(string type);
        Task<List<Watch>> getWatchInfo(string? category, string? type, string? name);
        Task<List<Watch>> getNewWatch();
        Task<Watch> getObjectWatchAsync(int watchId);
    }
}
