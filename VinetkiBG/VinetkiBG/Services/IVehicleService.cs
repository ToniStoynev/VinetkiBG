using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Domain;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface IVehicleService
    {
        void CreateVehicle(string name, string type, string country, string plateNumber, string ownerId);

        IEnumerable<VehicleViewAllModel> GetAll(string id);

        Vechile GetVechileById(string id);

        Vechile GetVehicleByCountryAndLicensePlate(string country, string licensePlate);
    }
}
