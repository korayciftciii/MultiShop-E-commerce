namespace MultiShop.Catalog.Dtos.Contact
{
    public class CreateContactDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
