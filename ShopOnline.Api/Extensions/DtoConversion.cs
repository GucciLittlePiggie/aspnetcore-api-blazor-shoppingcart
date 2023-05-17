using ShopOnline.Api.Models;
using ShopOnline.Models.Dto;

namespace ShopOnline.Api.Extensions
{
    public static class DtoConversion
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,
                                                IEnumerable<ProductCategory> productCategories)
        {
            return (from product in products
                    join productCategory in productCategories
                    on product.CategoryId equals productCategory.Id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImagePath = product.ImagePath,
                        Price = product.Price,
                        Qty = product.Qty,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name
                    }).ToList();
        }

		public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
												IEnumerable<Product> products)
		{
            return (from cartItem in cartItems
                          join product in products
                          on cartItem.ProductId equals product.Id
                          select new CartItemDto
                          {
                              Id = cartItem.Id,
                              ProductName = product.Name,
                              ProductDescription = product.Description,
                              ProductId = cartItem.ProductId,
                              ProductImageUrl = product.ImagePath,
                              Price = product.Price,
                              CartId = cartItem.CartId,
                              Qty = cartItem.Qty,
                              TotalPrices = product.Price * cartItem.Qty
                          }).ToList();
		}

		public static CartItemDto ConvertToDto(this CartItem cartItem,
												Product product)
		{
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageUrl = product.ImagePath,
                CartId = cartItem.CartId,
                Price = product.Price,
                Qty = cartItem.Qty,
                TotalPrices = product.Price * cartItem.Qty
            };
		}

		public static ProductDto ConvertToDto(this Product product, ProductCategory category)
        {
			return new ProductDto
			{
				Id = product.Id,
				Name = product.Name,
				Description = product.Description,
				Price = product.Price,
				ImagePath = product.ImagePath,
				CategoryId = product.CategoryId,
				CategoryName = category.Name,
                Qty = product.Qty,
			};
		}

        
    }
}
