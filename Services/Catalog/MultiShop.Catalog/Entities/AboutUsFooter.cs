using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class AboutUsFooter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContentId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
    }
}
