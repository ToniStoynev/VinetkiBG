using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.ViewModels
{
    public class VignetteDetailsViewModel
    {
        public string Id { get; set; }

        public string VehicleType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; }

        public string VehicleId { get; set; }
    }
}
