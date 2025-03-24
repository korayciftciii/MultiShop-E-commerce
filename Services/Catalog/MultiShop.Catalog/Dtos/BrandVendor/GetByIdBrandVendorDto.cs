namespace MultiShop.Catalog.Dtos.BrandVendor
{
    public class GetByIdBrandVendorDto
    {
        public string BrandId { get; set; }
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
