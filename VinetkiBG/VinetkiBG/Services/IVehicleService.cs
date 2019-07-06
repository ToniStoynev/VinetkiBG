using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinetkiBG.Services
{
    public interface IVehicleService
    {
        void CreateVehicle(string name, string type, string country, string plateNumber);
    }
}
