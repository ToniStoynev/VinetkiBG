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

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Vignette> Vignettes { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        public DbSet<Violation> Violations { get; set; }

        public DbSet<CredtiCard> CreditCards { get; set; }

        public VinetkiBGDbContext(DbContextOptions<VinetkiBGDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VinetkiBGUser>()
                .HasMany(x => x.Vehicles)
                .WithOne(x => x.Owner);

            builder.Entity<VinetkiBGUser>()
               .HasMany(x => x.CredtiCards)
               .WithOne(x => x.CardHolder);

            builder.Entity<Vehicle>()
                .HasOne(o => o.Owner);

            builder.Entity<Vehicle>()
                .HasOne(v => v.Vignette)
                .WithOne(v => v.Vehicle)
                .HasForeignKey<Vignette>(f => f.VehicleId);

            builder.Entity<Vehicle>()
             .HasOne(v => v.Violation)
             .WithOne(v => v.Vehicle)
             .HasForeignKey<Violation>(f => f.VehicleId);

            builder.Entity<Vignette>()
                .HasOne(r => r.Receipt)
                .WithOne(v => v.Vignette);

            builder.Entity<Receipt>()
               .HasOne(v => v.Vignette)
               .WithOne(v => v.Receipt);

            builder.Entity<Violation>()
                .HasOne(v => v.Vehicle)
                .WithOne(v => v.Violation);

            builder.Entity<CredtiCard>()
                .HasOne(x => x.CardHolder)
                .WithMany(x => x.CredtiCards)
                .HasForeignKey(f => f.CardHolderId);

            base.OnModelCreating(builder);
        }
    }
}
