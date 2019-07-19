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
        [StringLength(maximumLength: 2, ErrorMessage ="Category should be exatly 2 symbols", MinimumLength =2)]
        public string Caterory { get; set; }

        [Range(10, 150)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime StartDate { get; set; }


        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string VechileId { get; set; }

        [Required]
        public Vechile Vechile { get; set; }
    }
}
