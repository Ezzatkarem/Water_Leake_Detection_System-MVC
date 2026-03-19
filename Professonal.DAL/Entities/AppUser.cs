using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Professonal.DAL.Entities
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; }
    }
}
