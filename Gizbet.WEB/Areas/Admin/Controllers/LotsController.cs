using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using PagedList;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LotsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILotService _lotService;

        public LotsController(ILotService lotService)
        {
            _lotService = lotService;
            _mapper = GetMapper();
        }

        public async Task<ActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var lots = _mapper.Map<List<LotPublicModel>>(await _lotService.GetAllAsync());
            return View(lots.ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _lotService.DeleteAsync(new LotDTO { Id = id });
            return RedirectToAction("Index");
        }
    }
}