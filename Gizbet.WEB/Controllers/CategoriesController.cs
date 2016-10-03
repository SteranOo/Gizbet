using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Gizbet.BLL.Interfaces;
using Gizbet.WEB.Models;
using System.Threading.Tasks;
using AutoMapper;
using PagedList;
using static Gizbet.WEB.Configuration.AutoMapperConfigurationWEB;

namespace Gizbet.WEB.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = GetMapper();
        }

        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var res = Task.Run(() => _categoryService.GetAllAsync()).Result;
            var categories = _mapper.Map<List<CategoryModel>>(res);
            return PartialView("CategoryList", categories);
        }

        public async Task<ActionResult> Category(int id, int? page)
        {
            int pageSize = 6;
            int pageNumber = page ?? 1;
            var category = _mapper.Map<CategoryModel>(await _categoryService.GetAsync(id));
            ViewBag.CategoryName = category.Name;
            return View(category.Lots.Where(x=>!x.IsSold).ToPagedList(pageNumber, pageSize));
        }
    }
}