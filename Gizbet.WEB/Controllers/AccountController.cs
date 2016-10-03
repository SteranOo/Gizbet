using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Infrastructure;
using Gizbet.BLL.Interfaces;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;
using Gizbet.WEB.Models;
using Microsoft.Owin.Security;
using PagedList;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;      

        public AccountController(IUserService userService)
        {
            _userService = userService;
            _mapper = GetMapper();
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(ApplicationUserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserDTO userDto = new ApplicationUserDTO { UserName = model.UserName, Password = model.Password };
                ClaimsIdentity claim = await _userService.AuthenticateAsync(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    if (await _userService.IsBannedAsync(model.UserName))
                    {
                        ModelState.AddModelError("", "Данный пользователь временно заблокирован");
                         return View(model);
                    }
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(ApplicationUserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserDTO userDto = _mapper.Map<ApplicationUserDTO>(model);
                userDto.Role = "User";

                OperationDetails operationDetails = await _userService.CreateAsync(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        public async Task<ActionResult> ProfilePage(string userName)
        {
            if (userName == null)
                userName = User.Identity.Name;

            var user = _mapper.Map<ApplicationUserPublicModel>(await _userService.GetUserByUserNameAsync(userName));
            return View(user);
        }

        public async Task<ActionResult> Lots(int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;
            var user = _mapper.Map<ApplicationUserPublicModel>(await _userService.GetUserByUserNameAsync(User.Identity.Name));
            return View(user.Lots.ToPagedList(pageNumber, pageSize));
        }

        public async Task<ActionResult> Bids(int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var user = _mapper.Map<ApplicationUserPublicModel>(await _userService.GetUserByUserNameAsync(User.Identity.Name));
            var bids = _mapper.Map<List<BidModel>>(user.Bids.OrderByDescending(b => b.TimeOfBid));
            return View(bids.ToPagedList(pageNumber, pageSize));
        }
    }
}