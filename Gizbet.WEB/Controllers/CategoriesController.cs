using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using System.Threading.Tasks;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var categories = Mapper.Map<List<CategoryModel>>(Task.Run(() => _categoryService.GetAllAsync()).Result);
            return PartialView("CategoryList", categories);
        }

        public async Task<ActionResult> Category(int id)
        {
            var category = Mapper.Map<CategoryModel>(await _categoryService.GetAsync(id));
            return View(category);
        }
    }
}