using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VinetkiBG.Domain
{
    public class Violation
    {
        public string Id { get; set; }

        [Required]
        public string ViolationType { get; set; }


        [Required]
        public decimal PenaltyAmount { get; set; }

        [Required]
        public string VehicleId { get; set; }

        public Vechile Vehicle { get; set; }

        [Required]
        public string UserId { get; set; }

        public VinetkiBGUser Violator { get; set; }
    }
}
