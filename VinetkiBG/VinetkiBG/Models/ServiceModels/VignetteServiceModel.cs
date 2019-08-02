using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.ServiceModels
{
    public class VignetteServiceModel
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string VehicleId { get; set; }

        public string ReceiptId { get; set; }

        public string VehicleType { get; set; }
    }
}
