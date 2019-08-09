using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    
    public class Vehicle
    {
        private const string BrandErrorMessage = "Brand must be between 2 and 12 symbols";

        private const string CountryErrorMessage = "Country name must be between 2 and 12 symbols";

        private const string LicensePlateErrorMessage = "Plate number must be between 2 and 12 symbols";

        private const string TypeErrorMessage = "Vehicle type must be between 2 and 12 symbols";
        public string Id { get; set; }

        [StringLength(maximumLength:12, ErrorMessage = BrandErrorMessage, MinimumLength =2)]
        [Required]
        public string Brand { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = CountryErrorMessage, MinimumLength = 4)]
        [Required]
        public string Country { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = LicensePlateErrorMessage, MinimumLength = 4)]
        [Required]
        public string PlateNumber { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = TypeErrorMessage, MinimumLength = 3)]
        [Required]
        public string Type { get; set; }

        public string OwnerId { get; set; }
        public VinetkiBGUser Owner { get; set; }

        public string VignetteId { get; set; }
        public Vignette Vignette { get; set; }

        public string ViolationId { get; set; }
        public Violation Violation { get; set; }

    }
}
