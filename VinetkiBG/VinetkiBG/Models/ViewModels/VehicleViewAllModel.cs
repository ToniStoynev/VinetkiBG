using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ViewModels
{
    public class VehicleViewAllModel : IMapFrom<Vehicle>
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public string ViolationId { get; set; }
    }
}
