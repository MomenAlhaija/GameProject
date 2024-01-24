using Game.BL.DTO;
using Game.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Interface
{
    public interface ICategoryService
    {
         Task<IQueryable<ViewOrAddCategoryDTO?>?> GetCategories();
         Task AddCategory(AddCategoryDTO categoryDTO);
         Task UpdateCategory(ViewOrAddCategoryDTO categoryDTO);
         Task DeleteCategory(int id);
         Task<ViewOrAddCategoryDTO> GetCategoryById(int id);
    }
}
