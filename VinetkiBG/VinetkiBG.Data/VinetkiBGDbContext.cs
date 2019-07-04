using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VinetkiBG.Domain;

namespace VinetkiBG.Data
{
    public class VinetkiBGDbContext : IdentityDbContext<VinetkiBGUser, IdentityRole, string>
    {
        public DbSet<VinetkiBGUser> VinetkiBGUsers { get; set; }
        public VinetkiBGDbContext(DbContextOptions<VinetkiBGDbContext> options) : base(options)
        {

        }
    }
}
