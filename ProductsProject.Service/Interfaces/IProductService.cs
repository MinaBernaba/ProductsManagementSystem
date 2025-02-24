using ProductsProject.Data.Entites;
using ProductsProject.Data.Helper;

namespace ProductsProject.Service.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsWithCountryInfoAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product?> GetProductWithCountryInfoByIdAsync(int id);
        Task<bool> IsProductExistByIdAsync(int productId);
        Task<bool> AddProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Product product);
        Task<AddCategoriesToProductResponse> AddCategoriesToProductAsync(int productId, HashSet<int> categoryIds);
        Task<SetProductCategoriesResponse> SetProductCategoriesAsync(int productId, HashSet<int> categoryIds);

    }
}
