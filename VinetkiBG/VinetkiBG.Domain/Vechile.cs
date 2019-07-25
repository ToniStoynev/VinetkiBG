using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class Vechile
    {
        public string Id { get; set; }

        [StringLength(maximumLength:12, ErrorMessage ="Brand must be between 2 and 12 symbols", MinimumLength =2)]
        [Required]
        public string Brand { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Country name must be between 2 and 12 symbols", MinimumLength = 4)]
        [Required]
        public string Country { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "Plate number must be between 2 and 12 symbols", MinimumLength = 4)]
        [Required]
        public string PlateNumber { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Vehicle type must be between 2 and 12 symbols", MinimumLength = 3)]
        [Required]
        public string VechileType { get; set; }

        public string OwnerId { get; set; }
        public VinetkiBGUser Owner { get; set; }

        public string VignetteId { get; set; }
        public Vignette Vignette { get; set; }

        public string ViolationId { get; set; }
        public Violation Violation { get; set; }

    }
}
