using Game.DL.Interface;
using Game.Domain.Data;
using Game.Shared.EFRepositry;
using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace Game.DL.Implement
{
    public class CategoryRepositry : ICategoryRepositry
    {
        private readonly IEFRepositry _EFRepositry;
        private readonly AppDbContext _context;
        public CategoryRepositry(IEFRepositry EFRepositry,AppDbContext context)
        {
            _EFRepositry= EFRepositry;
            _context= context;
        }
      
        public async Task AddCategory(Category category)
        {
          await _EFRepositry.Insert(category);
        }

        public async Task DeleteCategory(Category category)
        {
          await _EFRepositry.Delete(category);
        }

        public async Task<IQueryable<Category?>?> GetCategoriesAsQueryable()
        {
            return  _context.Categories!.AsNoTracking().AsQueryable()??null;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var category=await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
            if (category is not null)
                return category;
            else
                throw new Exception($"Not Found Category with Id {id}");
        }

        public async Task UpdateCategory(Category category)
        {
            if (category is Category) {
                var getCategory = await GetCategoryById(category.Id);
                if (getCategory is not null)
                {
                     getCategory.Name= category.Name;
                     await _EFRepositry.Update(getCategory);
                }
            }
        }
    }
}
