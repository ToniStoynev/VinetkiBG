using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ViewModels
{
    public class UserViewModel : IMapFrom<VinetkiBGUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int VehiclesCount { get; set; }
    }
}
