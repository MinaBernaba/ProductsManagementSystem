using Microsoft.EntityFrameworkCore;
using ProductsProject.Data.Entites;
using ProductsProject.Data.Helper;
using ProductsProject.Infrastructure.Interfaces;
using ProductsProject.Service.Interfaces;

namespace ProductsProject.Service.Services
{
    public class ProductService(IUnitOfWork unitOfWork) : IProductService
    {
        public async Task<List<Product>> GetAllProductsAsync()
        => await unitOfWork.Products.GetAllNoTracking().ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id)
        => await unitOfWork.Products.GetByIdAsync(id);

        public async Task<List<Product>> GetAllProductsWithCountryInfoAsync()
       => await unitOfWork.Products.GetAllNoTracking().Include(x => x.Country).ToListAsync();


        public async Task<Product?> GetProductWithCountryInfoByIdAsync(int id)
        => await unitOfWork.Products.GetAllNoTracking().Where(x => x.ProductId.Equals(id)).Include(x => x.Country).FirstOrDefaultAsync();
        public async Task<bool> IsProductExistByIdAsync(int productId)
       => await unitOfWork.Products.IsExist(x => x.ProductId.Equals(productId));

        public async Task<bool> AddProductAsync(Product product)
        {
            await unitOfWork.Products.AddAsync(product);
            return await unitOfWork.SaveChangesAsync() > 0;

        }
        public async Task<bool> UpdateProductAsync(Product product)
        {
            unitOfWork.Products.Update(product);
            return await unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteProductAsync(Product product)
        {
            unitOfWork.Products.Delete(product);
            return await unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<AddCategoriesToProductResponse> AddCategoriesToProductAsync(int productId, HashSet<int> categoryIds)
        {

            var response = new AddCategoriesToProductResponse();

            HashSet<int> existingCategoryIds = unitOfWork.Categories
                    .GetAllNoTracking()
                    .Where(x => categoryIds.Contains(x.CategoryId))
                    .Select(x => x.CategoryId)
                    .ToHashSet();

            HashSet<int> existingProductCategoryIds = unitOfWork.ProductCategories
                .GetAllNoTracking()
                .Where(x => x.ProductId == productId && categoryIds.Contains(x.CategoryId))
                .Select(x => x.CategoryId)
                .ToHashSet();

            HashSet<ProductCategory> newProductCategories = new HashSet<ProductCategory>();

            foreach (var categoryId in categoryIds)
            {
                if (!existingCategoryIds.Contains(categoryId) || existingProductCategoryIds.Contains(categoryId))
                {
                    response.InvalidCategoriesIds.Add(categoryId);
                    continue;
                }

                response.ValidCategoriesIds.Add(categoryId);
                var productCategory = new ProductCategory()
                {
                    CategoryId = categoryId,
                    ProductId = productId
                };
                newProductCategories.Add(productCategory);
            }
            if (newProductCategories.Count != 0)
                await unitOfWork.ProductCategories.AddRangeAsync(newProductCategories);

            if (await unitOfWork.SaveChangesAsync() == 0)
                response.Message = "All Categories are invalid!";

            else if (response.InvalidCategoriesIds.Count > 0)
                response.Message = $"Categories added successfully However, the following category IDs were not valid: {string.Join(", ", response.InvalidCategoriesIds)}";

            else response.Message = "Categories added successfully.";

            return response;
        }

        public async Task<SetProductCategoriesResponse> SetProductCategoriesAsync(int productId, HashSet<int> categoryIds)
        {
            var response = new SetProductCategoriesResponse();


            HashSet<int> allCategoryIdsInDbAndHashSet = unitOfWork.Categories
                .GetAllNoTracking()
                .Where(x => categoryIds.Contains(x.CategoryId))
                .Select(x => x.CategoryId)
                .ToHashSet();

            HashSet<int> AllCategoryIdsAssignedToProduct = unitOfWork.ProductCategories
                .GetAllNoTracking()
                .Where(x => x.ProductId == productId)
                .Select(x => x.CategoryId)
                .ToHashSet();


            HashSet<int> categoriesIdsToRemove = AllCategoryIdsAssignedToProduct.Except(categoryIds).ToHashSet();


            HashSet<ProductCategory> categoriesToAdd = categoryIds.Except(AllCategoryIdsAssignedToProduct)
                .Where(allCategoryIdsInDbAndHashSet.Contains)
                .Select(categoryId => new ProductCategory { ProductId = productId, CategoryId = categoryId })
                .ToHashSet();


            if (categoriesIdsToRemove.Count > 0)
            {
                var categoriesToRemove = unitOfWork.ProductCategories.GetAllNoTracking()
                    .Where(x => x.ProductId == productId && categoriesIdsToRemove.Contains(x.CategoryId));

                unitOfWork.ProductCategories.DeleteRange(categoriesToRemove);
            }

            if (categoriesToAdd.Count > 0)
                await unitOfWork.ProductCategories.AddRangeAsync(categoriesToAdd);

            if (await unitOfWork.SaveChangesAsync() > 0)
            {
                response.Message = "Categories updated successfully.";
                response.AddedCategories = categoriesToAdd.Select(x => x.CategoryId).ToHashSet();
                response.RemovedCategories = categoriesIdsToRemove;
                response.InvalidCategories = categoryIds.Except(allCategoryIdsInDbAndHashSet).ToHashSet();
            }
            else
                response.Message = "No changes were made.";


            return response;
        }
    }
}
