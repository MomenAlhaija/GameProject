using Game.BL.DTO;
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
        public IActionResult Add()
        {
            var model = new AddCategoryDTO();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryDTO category)
        {
           await _categoryService.AddCategory(category);
           return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id) 
        { 
           var category=await _categoryService.GetCategoryById(id);
           return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ViewOrAddCategoryDTO input)
        {
            await _categoryService.UpdateCategory(input);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
