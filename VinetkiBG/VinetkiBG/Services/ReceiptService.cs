using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;

namespace VinetkiBG.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly VinetkiBGDbContext db;

        public ReceiptService(VinetkiBGDbContext db)
        {
            this.db = db;
        }
    }
}
