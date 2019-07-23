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
        private readonly VinetkiBGDbContext context;

        public UserService(VinetkiBGDbContext context)
        {
            this.context = context;
        }
        public VinetkiBGUser GetUserById(string id)
        {
            var user =  this.context.Users
                .Include(x => x.Vechiles)
                .FirstOrDefault(x => x.Id == id);

            return user;
        }

        public int GetVehicleCountByUserId(string id)
        {
            var result = context.Users.Where(x => x.Id == id).Select(x => x.Vechiles.Count()).FirstOrDefault();

            return result;
        }
    }
}
