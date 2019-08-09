using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VinetkiBG.Domain;
using VinetkiBG.Models.ServiceModels;
using VinetkiBG.Services.Mapping;

namespace VinetkiBG.Tests.Common
{
    public static class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(VehicleServiceModel).GetTypeInfo().Assembly,
                typeof(Vehicle).GetTypeInfo().Assembly);
        }
    }
}
