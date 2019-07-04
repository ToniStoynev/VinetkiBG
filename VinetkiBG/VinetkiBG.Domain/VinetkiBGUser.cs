using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VinetkiBG.Domain
{
    public class VinetkiBGUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
