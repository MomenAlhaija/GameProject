using Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DL.Interface
{
    public interface ICategoryRepositry
    {
        Task<IQueryable<Category?>?> GetCategoriesAsQueryable();
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task<Category> GetCategoryById(int id);
    }
}
