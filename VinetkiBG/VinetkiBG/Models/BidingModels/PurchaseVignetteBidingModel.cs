using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Models.BidingModels
{
    public class PurchaseVignetteBidingModel
    {
        [Required]
        public string VignetteType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
