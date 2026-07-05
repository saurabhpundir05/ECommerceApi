using ECommerce.Core.Enums;

namespace ECommerce.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public decimal? AverageRating { get; set; }
        public int BuyCount { get; set; }
    }
}
