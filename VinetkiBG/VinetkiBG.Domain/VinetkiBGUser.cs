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
            this.Vehicles = new HashSet<Vehicle>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
