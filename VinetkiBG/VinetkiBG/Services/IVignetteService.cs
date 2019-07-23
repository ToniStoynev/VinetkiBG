using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface IVignneteService
    {
        Vignette BuyVignette(string type, decimal price, DateTime starDate, DateTime endDate, string vehicleId);

        Vignette CheckVignette(string country, string licensePlate);

        Vignette GetVignetteById(string id);

    }
}
