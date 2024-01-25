using Game.BL.DTO;

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
