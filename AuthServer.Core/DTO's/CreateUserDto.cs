﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTO_s
{
    //Dtolar clientlara giden modellerdir
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
