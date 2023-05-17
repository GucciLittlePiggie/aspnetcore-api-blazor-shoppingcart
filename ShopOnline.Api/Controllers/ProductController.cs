using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Models;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dto;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            try
            {
                var products = await repository.GetAllAsync();
                var productCategories = await repository.GetAllCategoriesAsync();

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetAsync(int id)
        {
            try
            {
				var product = await repository.GetAsync(id);

				if (product == null)
				{
					return NotFound();
				}
				var category = await repository.GetCategoryAsync(product.CategoryId);
				var dto = product.ConvertToDto(category);

				return Ok(dto);
			}

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
