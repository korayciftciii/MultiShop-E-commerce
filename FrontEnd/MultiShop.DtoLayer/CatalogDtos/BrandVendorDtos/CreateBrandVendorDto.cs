using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CatalogDtos.BrandVendorDtos
{
 public   class CreateBrandVendorDto
    {
        public string BrandName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
