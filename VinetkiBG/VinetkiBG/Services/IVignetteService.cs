using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface IVignneteService
    {
        string BuyVignette(VignetteServiceModel vignetteServiceModel);

        VignetteServiceModel CheckVignette(CheckVehicleServiceModel checkVehicleServiceModel);

        VignetteServiceModel GetVignetteById(string id);

    }
}
