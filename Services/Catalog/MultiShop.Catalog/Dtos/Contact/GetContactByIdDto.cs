namespace MultiShop.Catalog.Dtos.Contact
{
    public class GetContactByIdDto
    {
        public string ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
