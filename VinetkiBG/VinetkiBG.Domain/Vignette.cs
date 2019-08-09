using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class Vignette
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Range(10, 150)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string VehicleId { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        public string RecipietId { get; set; }
        public Receipt Receipt { get; set; }
    }
}
