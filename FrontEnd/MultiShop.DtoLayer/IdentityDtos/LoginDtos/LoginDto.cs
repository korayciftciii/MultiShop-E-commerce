﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.IdentityDtos.LoginDtos
{
    public class LoginDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public bool isPersistence { get; set; }
    }
}
