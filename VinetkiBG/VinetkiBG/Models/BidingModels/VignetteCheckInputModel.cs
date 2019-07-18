using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.BidingModels
{
    public class VignetteCheckInputModel
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string PlateNumber { get; set; }
    }
}
