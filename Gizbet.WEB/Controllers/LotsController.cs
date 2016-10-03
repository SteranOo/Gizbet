using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class LotsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILotService _lotService;
        private readonly ICategoryService _categoryService;

        public LotsController(ILotService lotService,ICategoryService categoryService)
        {
            _lotService = lotService;
            _categoryService = categoryService;
            _mapper = GetMapper();
        }

        public async Task<ActionResult> Lot(int id)
        {
            var lotModel = _mapper.Map<LotPublicModel>(await _lotService.GetAsync(id));
            if (lotModel.IsSold)
                return View("LotSold", lotModel);
            return View(lotModel);
        }

        [HttpPost]
        public async Task<PartialViewResult> SearchResult(string request, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;
            request = request ?? "";
            var res = _mapper.Map<List<LotPublicModel>>(await _lotService.FindByAsync(x=>x.Name.Contains(request))); 
            return PartialView(res.Where(x=>!x.IsSold).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Search()
        {
            return View();
        }

        public async Task<ActionResult> Add()
        {
            ViewBag.Categories = _mapper.Map<List<CategoryModel>>(await _categoryService.GetAllAsync());
            return View();
        }

        public async Task<ActionResult> Reply(int id)
        {
            ViewBag.Categories = _mapper.Map<List<CategoryModel>>(await _categoryService.GetAllAsync());
            var lot = await _lotService.GetAsync(id);
            return View("Add", _mapper.Map<LotAddModel>(lot));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(LotAddModel lotModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _mapper.Map<List<CategoryModel>>(await _categoryService.GetAllAsync());
                return View(lotModel);
            }

            string fileName = "no_photo.jpg";

            if (lotModel.UploadImage != null)
            {
                fileName = System.IO.Path.GetFileName(lotModel.UploadImage.FileName);
                lotModel.UploadImage.SaveAs(Server.MapPath("~/Content/Images/UserImages/" + fileName));
            }

            var lot = _mapper.Map<LotDTO>(lotModel);

            lot.OwnerId = int.Parse(User.Identity.GetUserId());
            lot.TimeOfPosting = DateTime.Now;
            lot.ImageName = fileName;

            await _lotService.AddAsync(lot);
            return View("SuccessLotAdd");
        }

        [HttpPost]
        public async Task<ActionResult> MakeBid(int lotId)
        {
            await _lotService.MakeBidAsync(lotId, int.Parse(User.Identity.GetUserId()));
            return RedirectToAction("Lot", new {id = lotId});
        }

        [HttpPost]
        public async Task<ActionResult> Buy(int lotId)
        {
            await _lotService.BuyLotAsync(lotId, int.Parse(User.Identity.GetUserId()));
            return RedirectToAction("Lot", new { id = lotId });
        }

        [HttpPost]
        public async Task<ActionResult> DeleteLot(int lotid)
        {
            await _lotService.DeleteLotByIdAsync(lotid);
            return View("SuccessLotRemove");
        }
    }
}