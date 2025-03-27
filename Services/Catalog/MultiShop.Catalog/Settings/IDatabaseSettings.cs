namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string  CategoryCollectionName{ get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string SpecialOfferCollectionName { get; set; }
        public string ServiceCardCollectionName { get; set; }
        public string GeneralOfferCollectionName { get; set; }
        public string BrandVendorCollectionName { get; set; }
        public string AboutUsFooterCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }


    }
}
