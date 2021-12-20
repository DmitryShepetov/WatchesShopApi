using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Repository;
using WatchesShopReborn.ViewModels;

namespace WatchesShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IWatch watchRep;
        public HomeController(IWatch watchRep)
        {
            this.watchRep = watchRep;
        }
        // GET api/Home/
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var homeWatch = new HomeViewModel()
            {
                favWatch = await watchRep.getFavWatch(),
                getNewWatch = await watchRep.getNewWatch()
            };
            try
            {
                return Ok(homeWatch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
