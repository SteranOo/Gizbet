using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Gizbet.BLL.DTO;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = GetMapper();
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(_mapper.Map<List<CategoryModel>>(categories));
        }

        [HttpPost]
        public async Task<ActionResult> Add(string name)
        {
            await _categoryService.AddAsync(new CategoryDTO {Name = name});
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(new CategoryDTO { Id = id});
            return RedirectToAction("Index");
        }
    }
}
