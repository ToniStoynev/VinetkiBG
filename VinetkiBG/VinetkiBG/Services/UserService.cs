using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinetkiBG.Data;
using VinetkiBG.Domain;
using VinetkiBG.Models.ViewModels;

namespace VinetkiBG.Services
{
    public class UserService : IUserService
    {
        private readonly VinetkiBGDbContext db;

        public UserService(VinetkiBGDbContext db)
        {
            this.db = db;
        }
        public VinetkiBGUser GetUserById(string id)
        {
            var user =  this.db.Users
                .Include(x => x.Vechiles)
                .FirstOrDefault(x => x.Id == id);

            return user;
        }

        public int GetVehicleCountByUserId(string id)
        {
            var result = db.Users.Where(x => x.Id == id)
                .Select(x => x.Vechiles.Count())
                .FirstOrDefault();

            return result;
        }

    }
}
