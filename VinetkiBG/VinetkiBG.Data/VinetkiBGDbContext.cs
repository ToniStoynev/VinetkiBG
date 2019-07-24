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

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Violation> Violations { get; set; }

        public VinetkiBGDbContext(DbContextOptions<VinetkiBGDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VinetkiBGUser>()
                .HasMany(x => x.Vechiles)
                .WithOne(x => x.Owner);

            builder.Entity<VinetkiBGUser>()
               .HasMany(x => x.Violations)
               .WithOne(x => x.Violator);

            builder.Entity<Vechile>()
                .HasOne(o => o.Owner);

            builder.Entity<Vechile>()
                .HasOne(v => v.Vignette)
                .WithOne(v => v.Vechile)
                .HasForeignKey<Vignette>(f => f.VechileId);

            builder.Entity<Vignette>()
                .HasOne(r => r.Receipt)
                .WithOne(v => v.Vignette);

            builder.Entity<Receipt>()
               .HasOne(v => v.Vignette)
               .WithOne(v => v.Receipt);

            builder.Entity<Violation>()
                .HasOne(v => v.Vehicle)
                .WithMany(v => v.Violations);

            builder.Entity<Violation>()
                .HasOne(v => v.Violator)
                .WithMany(v => v.Violations);

            base.OnModelCreating(builder);
        }
    }
}
