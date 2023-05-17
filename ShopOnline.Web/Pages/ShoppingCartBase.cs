using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dto;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class ShoppingCartBase: ComponentBase
	{
		[Inject]
		public IShoppingCartService ShoppingCartService{ get; set; }

        public List<CartItemDto> ShoppingCartItems { get; set; }

        public decimal TotalPrice { get; set; }

        public string ErrorMessage { get; set; }

		protected async Task DeleteItem_Click(int id)
		{
			var item = await ShoppingCartService.RemoveItemAsync(id);
			RemoveCartItem(id);

		}
		private void RemoveCartItem(int id)
		{
			var item = GetCartItem(id);
			ShoppingCartItems.Remove(item);
		}

		private CartItemDto GetCartItem(int id)
		{
			return ShoppingCartItems.FirstOrDefault(x => x.Id == id);

		}

        protected override async Task OnInitializedAsync()
		{
			try
			{
				await LoadItems();
				 
				ShoppingCartService.CartItemAdded += async (sender, e) =>
				{
					await LoadItems();
					StateHasChanged();
				};
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
		}

		private async Task LoadItems ()
		{
			ShoppingCartItems = await ShoppingCartService.GetCartItemsAsync(HardCoded.userId);

		}


	}
}
