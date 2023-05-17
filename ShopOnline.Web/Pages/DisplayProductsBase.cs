using System;
using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dto;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages
{
	public class DisplayProductsBase: ComponentBase
	{
		[Parameter]
		public IEnumerable<ProductDto> Products { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }




    }
}
