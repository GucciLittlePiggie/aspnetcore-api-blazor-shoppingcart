using ShopOnline.Api.Models;

namespace ShopOnline.Api.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync();
        Task<ProductCategory> GetCategoryAsync(int id);
    }
}
