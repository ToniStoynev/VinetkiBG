using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Models.BidingModels
{
    public class AddVechileBidingModel : IMapTo<VehicleServiceModel>
    {
        private const string BrandErrorMessage = "Brand must be between 2 and 12 symbols";

        private const string CountryErrorMessage = "Country name must be between 2 and 12 symbols";

        private const string LicensePlateErrorMessage = "Plate number must be between 2 and 12 symbols";


        [Required]
        [StringLength(maximumLength:10, ErrorMessage = BrandErrorMessage, MinimumLength =3)]
        public string Brand { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = CountryErrorMessage, MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [StringLength(maximumLength: 12, ErrorMessage = LicensePlateErrorMessage, MinimumLength = 4)]
        public string PlateNumber { get; set; }


    }
}
