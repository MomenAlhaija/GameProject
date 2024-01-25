using Game.Domain.Entity;

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
