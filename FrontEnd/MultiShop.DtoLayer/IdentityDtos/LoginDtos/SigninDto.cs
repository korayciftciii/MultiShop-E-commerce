using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.IdentityDtos.LoginDtos
{
public class SigninDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsPersistence { get; set; } = false;
    }
}
