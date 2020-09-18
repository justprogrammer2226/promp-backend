using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Promp.DAL.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
