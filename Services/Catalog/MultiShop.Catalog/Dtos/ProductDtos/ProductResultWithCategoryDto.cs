using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ProductResultWithCategoryDto
    {

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductDiscountedPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
