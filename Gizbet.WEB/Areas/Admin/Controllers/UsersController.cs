using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AutoMapper;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using PagedList;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _mapper = GetMapper();
        }

        public async Task<ActionResult> Index(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var users = _mapper.Map<List<ApplicationUserPublicModel>>(await _userService.GetAllAsync());
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Ban(string userName)
        {
            await _userService.BanUserAsync(userName);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UnBan(string userName)
        {
            await _userService.UnBanUserAsync(userName);
            return RedirectToAction("Index");
        }
    }
}