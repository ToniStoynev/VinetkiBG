using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class Receipt
    {
        public string Id { get; set; }

        [Required]
        public string LicensePlate { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string VignetteId { get; set; }

        public Vignette Vignette { get; set; }


    }
}
