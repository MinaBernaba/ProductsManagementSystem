using ProductsProject.Data.Entites;

namespace ProductsProject.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> IsCategoryExistByIdAsync(int categoryId);
        Task<bool> IsCategoryExistByNameAsync(string categoryName);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Category category);
    }
}
