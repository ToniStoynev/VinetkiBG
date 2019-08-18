using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ServiceModels
{
    public class VehicleServiceModel : IMapFrom<Vehicle>, IMapFrom<AddVechileBidingModel>, IMapTo<Vehicle>
    {
        public string Id { get; set; }
        public string Brand { get; set; }

        public string Type { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public string OwnerId { get; set; }

        public string ViolationId { get; set; }
    }
}
