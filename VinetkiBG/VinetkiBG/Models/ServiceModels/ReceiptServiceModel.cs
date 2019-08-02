using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.ServiceModels
{
    public class ReceiptServiceModel
    {
        public string Id { get; set; }

        public string LicensePlate { get; set; }

        public string VehicleType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public string VignetteId { get; set; }

    }
}
