using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ServiceModels
{
    public class ViolationServiceModel : IMapFrom<Violation>, IMapTo<Violation>
    {
        public string Id { get; set; }
        public string ViolationType { get; set; }

        public string Road { get; set; }

        public DateTime ViolationDate { get; set; }

        public decimal PenaltyAmount { get; set; }

        public string VehicleId { get; set; }
    }
}
