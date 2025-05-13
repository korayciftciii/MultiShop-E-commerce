using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.ContactDtos
{
   public class UpdateContactDto
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
