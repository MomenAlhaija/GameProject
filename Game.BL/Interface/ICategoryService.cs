using Game.BL.DTO;
using System.Web.Mvc;

namespace Game.BL.Interface
{
    public interface ICategoryService
    {
         Task<IQueryable<ViewOrAddCategoryDTO?>?> GetCategories();
         Task AddCategory(AddCategoryDTO categoryDTO);
         Task UpdateCategory(ViewOrAddCategoryDTO categoryDTO);
         Task DeleteCategory(int id);
         Task<ViewOrAddCategoryDTO> GetCategoryById(int id);
         Task<IEnumerable<SelectListItem>> GetSelectListCategories();
    }
}
