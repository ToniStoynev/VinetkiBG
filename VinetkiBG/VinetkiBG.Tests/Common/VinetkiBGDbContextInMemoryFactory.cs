using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VinetkiBG.Data;

namespace VinetkiBG.Tests.Common
{
    public static class VinetkiBGDbContextInMemoryFactory
    {
        public static VinetkiBGDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<VinetkiBGDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new VinetkiBGDbContext(options);
        }
    }
}
