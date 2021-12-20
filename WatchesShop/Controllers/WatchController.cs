using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WatchesShop.Data;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;
using WatchesShopReborn.ViewModels;

namespace WatchesShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WatchController : Controller
    {
        private readonly IWatch watchRep;
        private readonly IWatchCategory categoryRep;
        private readonly IWatchImage watchImageRep;
        private readonly AppDBContext appDBContext;
        public WatchController(AppDBContext appDBContext,IWatch watchRep, IWatchCategory categoryRep, IWatchImage watchImageRep)
        {
            this.appDBContext = appDBContext;
            this.watchRep = watchRep;
            this.categoryRep = categoryRep;
            this.watchImageRep = watchImageRep;
        }
        // GET api/watch/
        [HttpGet]
        public async Task<ActionResult> GetWatch()
        {
            try
            {
                return Ok(await watchRep.AllWatch());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("WatchInfo")]
        public async Task<ActionResult> GetWatchCategory(string category = null, string type = null, string name = null)
        {
            try
            {
                if (category != null)
                {
                    return Ok(await watchRep.getWatchInfo(category, type, name));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

       

        // PUT api/watch/
        [HttpPut]
        public async Task<ActionResult<Watch>> Put(Watch watch)
        {
            if (watch == null)
            {
                return BadRequest();
            }
            if (!appDBContext.Watch.Any(x => x.id == watch.id))
            {
                return NotFound();
            }

            appDBContext.Update(watch);
            await appDBContext.SaveChangesAsync();
            return Ok(watch);
        }

        // DELETE api/watch/5
        [HttpDelete("{id}")]
        public ActionResult<Watch> Delete(int id)
        {
            Watch watch = appDBContext.Watch.FirstOrDefault(x => x.id == id);
            if (watch == null)
            {
                return NotFound();
            }
            appDBContext.Watch.Remove(watch);
            appDBContext.SaveChanges();
            return Ok(watch);
        }

    }
}
