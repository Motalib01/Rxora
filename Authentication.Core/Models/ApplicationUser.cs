﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}
