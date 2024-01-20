using Game.BL.Interface;
using Game.DL.Interface;
using Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Implement
{

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositry _categoryRepositry;
        public CategoryService(ICategoryRepositry categoryRepositry)
        {
            _categoryRepositry = categoryRepositry;  
        }
        public Task<IQueryable<Category?>?> GetCategories()
        {
            return _categoryRepositry.GetCategoriesAsQueryable();
        }
    }
}
