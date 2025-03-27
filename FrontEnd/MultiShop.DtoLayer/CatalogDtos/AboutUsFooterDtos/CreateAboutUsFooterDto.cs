using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.AboutUsFooterDtos
{
   public class CreateAboutUsFooterDto
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
    }
}
