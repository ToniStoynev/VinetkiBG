﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.BidingModels
{
    public class AddVechileBidingModel
    {
        [Required]
        [StringLength(maximumLength:10, ErrorMessage ="Name should be between 3 and 10 symbols", MinimumLength =3)]
        public string FriendlyName { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "Country should be between 3 and 12 symbols", MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [StringLength(maximumLength: 12, ErrorMessage = "Plate number should be between 4 and 12 symbols", MinimumLength = 4)]
        public string PlateNumber { get; set; }


    }
}