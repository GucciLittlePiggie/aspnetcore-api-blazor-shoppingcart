using ShopOnline.Models.Dto;

namespace ShopOnline.Web.Services.Contracts
{
	public interface IShoppingCartService
	{
		Task<List<CartItemDto>> GetCartItemsAsync(string userId);
		Task<CartItemDto> AddItemAsync(CartItemToAddDto item);
		Task<CartItemDto> RemoveItemAsync (int id);
		event EventHandler CartItemAdded;

	}
}
