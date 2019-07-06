using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public interface IVehicleService
    {
        void CreateVehicle(string name, string type, string country, string plateNumber);

        IEnumerable<VehicleViewAllModel> GetAll();
    }
}
