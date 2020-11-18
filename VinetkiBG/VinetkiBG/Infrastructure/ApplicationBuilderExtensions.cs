namespace VinetkiBG.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using VinetkiBG.Data;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder InitialDBSeed(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<VinetkiBGDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        });
                    }
                    context.SaveChanges();
                }
            }

            return app;
        }
    }
}
