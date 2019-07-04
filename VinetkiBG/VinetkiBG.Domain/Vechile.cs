using System;
using System.Collections.Generic;
using System.Text;

namespace VinetkiBG.Domain
{
    public class Vechile
    {
        public string Id { get; set; }
        public string Brand { get; set; }

        public string Country { get; set; }

        public string PlateNumber { get; set; }

        public VechileType Type { get; set; }

        public string OwnerId { get; set; }
        public VinetkiBGUser Owner { get; set; }
    }
}
