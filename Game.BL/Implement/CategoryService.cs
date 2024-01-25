using Game.BL.DTO;
using Game.BL.Interface;
using Game.DL.Interface;
using Game.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace Game.BL.Implement
{

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositry _categoryRepositry;
        public CategoryService(ICategoryRepositry categoryRepositry)
        {
            _categoryRepositry = categoryRepositry;  
        }

        public async Task AddCategory(AddCategoryDTO categoryDTO)
        {
           await _categoryRepositry.AddCategory(new Category  { Name = categoryDTO.Name });
        }

        public async Task DeleteCategory(int id)
        {
            var category= await _categoryRepositry.GetCategoryById(id);
            if (category is Category && category is not null)
                await _categoryRepositry.DeleteCategory(category);
            else
                throw new Exception($"The Category With Id:{id} is not Found");
        }

        public async Task<IQueryable<ViewOrAddCategoryDTO?>?> GetCategories()
        {
            var categories=await _categoryRepositry.GetCategoriesAsQueryable();
            return  categories.Select(c=>new ViewOrAddCategoryDTO {Id=c!.Id,Name=c!.Name }).AsQueryable();
        }

        public async Task<ViewOrAddCategoryDTO> GetCategoryById(int id)
        {
            var category=await  _categoryRepositry.GetCategoryById(id);
            return new ViewOrAddCategoryDTO {Id=category.Id,Name=category.Name};
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectListCategories()
        {
            var categories = await _categoryRepositry.GetCategoriesAsQueryable();
            return categories.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).AsNoTracking().OrderBy(c => c.Text).ToList();
        }

        public async Task UpdateCategory(ViewOrAddCategoryDTO category)
        {
            await _categoryRepositry.UpdateCategory(new Category { Id=category.Id,Name=category.Name});
        }
    }
}
