using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILotService _lotService;

        public HomeController(ILotService lotService)
        {
            _lotService = lotService;
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var lots = await _lotService.GetActiveLotsAsync();
            var lotModels = Mapper.Map<List<LotPublicModel>>(lots)
                .OrderBy(l => l.TimeOfPosting.AddHours(l.HoursDuration));
            return View(lotModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}