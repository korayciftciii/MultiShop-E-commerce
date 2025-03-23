namespace MultiShop.Catalog.Dtos.GeneralOfferDtos
{
    public class ResultGeneralOfferDto
    {
        public string OfferId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string ButtonTitle { get; set; }
        public int DiscountRate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
