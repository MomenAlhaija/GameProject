using Game.BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            var categories=await _categoryService.GetCategories();
            return View(categories?.AsEnumerable());
        }
    }
}
