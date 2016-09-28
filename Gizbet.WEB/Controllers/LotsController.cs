using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using Microsoft.AspNet.Identity;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class LotsController : Controller
    {
        private readonly ILotService _lotService;
        private readonly ICategoryService _categoryService;

        public LotsController(ILotService lotService,ICategoryService categoryService)
        {
            _lotService = lotService;
            _categoryService = categoryService;
        }

        public async Task<ActionResult> Lot(int id)
        {
            var lotModel = Mapper.Map<LotPublicModel>(await _lotService.GetAsync(id));
            if (lotModel.IsSold)
                return View("LotSold", lotModel);
            return View(lotModel);
        }

        public async Task<ActionResult> Add()
        {
            ViewBag.Categories = Mapper.Map<List<CategoryModel>>(await _categoryService.GetAllAsync());
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(LotAddModel lotModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = Mapper.Map<List<CategoryModel>>(await _categoryService.GetAllAsync());
                return View(lotModel);
            }

            string fileName = "no_photo.jpg";

            if (lotModel.UploadImage != null)
            {
                fileName = System.IO.Path.GetFileName(lotModel.UploadImage.FileName);
                lotModel.UploadImage.SaveAs(Server.MapPath("~/Content/Images/UserImages/" + fileName));
            }

            var lot = Mapper.Map<LotDTO>(lotModel);

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