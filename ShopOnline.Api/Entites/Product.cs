using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
         
        [Precision(5, 2)]
        public decimal Price { get; set; }

        public int Qty { get; set; }
        public int CategoryId { get; set; }
    }
}
