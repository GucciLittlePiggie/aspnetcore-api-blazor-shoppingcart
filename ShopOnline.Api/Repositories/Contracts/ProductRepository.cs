using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models;

namespace ShopOnline.Api.Repositories.Contracts
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            return product;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<ProductCategory> GetCategoryAsync(int id)
        {
            var category = await context.ProductCategories.FindAsync(id);
            return category;

        }
        public async Task<IEnumerable<ProductCategory>> GetAllCategoriesAsync()
        {
            var categories = await context.ProductCategories.ToListAsync();
            return categories;
        }


    }
}
