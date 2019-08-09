using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.ViewModels
{
    public class ReceiptMyViewModel : IMapFrom<ReceiptServiceModel>
    {
        public string Id { get; set; }

        public string LicensePlate { get; set; }

        public string VehicleType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
    }
}
