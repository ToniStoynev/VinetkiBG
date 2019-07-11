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

        public DbSet<Vechile> Vechiles { get; set; }

        public DbSet<Vignette> Vignettes { get; set; }
        public VinetkiBGDbContext(DbContextOptions<VinetkiBGDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VinetkiBGUser>()
                .HasMany(x => x.Vechiles)
                .WithOne(x => x.Owner);

            builder.Entity<Vechile>()
                .HasOne(o => o.Owner);

            builder.Entity<Vechile>()
                .HasOne(v => v.Vignette)
                .WithOne(v => v.Vechile)
                .HasForeignKey<Vignette>(f => f.VechileId);

            base.OnModelCreating(builder);
        }
    }
}
