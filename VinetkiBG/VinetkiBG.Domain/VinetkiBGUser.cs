using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VinetkiBG.Domain
{
    public class VinetkiBGUser : IdentityUser
    {
        public VinetkiBGUser()
        {
            this.Vechiles = new HashSet<Vechile>();
            this.Violations = new HashSet<Violation>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Vechile> Vechiles { get; set; }

        public ICollection<Violation> Violations { get; set; }

    }
}
