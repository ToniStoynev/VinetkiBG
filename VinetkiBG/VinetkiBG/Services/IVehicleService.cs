using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.BidingModels;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface IVehicleService
    {
        bool CreateVehicle(VehicleServiceModel vehicleServiceModel);
        bool EditVehicle(EditVehicleBindingModel model);

        IQueryable<VehicleViewAllModel> GetAll(string id);

        VehicleServiceModel GetVechileById(string id);

        VehicleServiceModel GetVechileByCountryAndLicensePlate(CheckVehicleServiceModel checkVehicleServiceModel);
    }
}
