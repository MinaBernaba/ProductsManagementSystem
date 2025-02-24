using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
    {
        public async Task<List<Category>> GetAllCategoriesAsync()
        => await unitOfWork.Categories.GetAllNoTracking().ToListAsync();

        public async Task<Category> GetCategoryByIdAsync(int id)
        => await unitOfWork.Categories.GetByIdAsync(id);

        public async Task<bool> IsCategoryExistByIdAsync(int categoryId)
       => await unitOfWork.Categories.IsExist(x => x.CategoryId.Equals(categoryId));

        public async Task<bool> IsCategoryExistByNameAsync(string categoryName)
        => await unitOfWork.Categories.IsExist(x => x.CategoryName.Equals(categoryName));

        public async Task<bool> AddCategoryAsync(Category category)
        {
            await unitOfWork.Categories.AddAsync(category);
            return await unitOfWork.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            unitOfWork.Categories.Update(category);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            unitOfWork.Categories.Delete(category);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
