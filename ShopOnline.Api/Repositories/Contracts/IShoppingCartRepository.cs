using ShopOnline.Api.Models;
using ShopOnline.Models.Dto;

namespace ShopOnline.Api.Repositories.Contracts
{
	public interface IShoppingCartRepository
	{
		Task<CartItem> Add(CartItemToAddDto item);
		Task<CartItem> Update(int id, CartItemUpdateQtyDto item);
		Task<CartItem> Delete(int id);
		Task<CartItem> GetItem(int id);
		Task<IEnumerable<CartItem>> GetAll(string userId);
	}
}
