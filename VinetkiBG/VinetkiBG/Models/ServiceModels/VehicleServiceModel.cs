using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.ServiceModels
{
    public class VehicleServiceModel
    {
        public string Brand { get; set; }

        public string VehicleType { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        public string ViolationId { get; set; }
    }
}
