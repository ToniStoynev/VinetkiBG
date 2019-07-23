using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.ViewModels
{
    public class ReceiptMyViewModel
    {
        public string Id { get; set; }

        public string LicencePlate { get; set; }

        public string VehicleType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
    }
}
