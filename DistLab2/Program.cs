using DistLab2.Areas.Identity.Data;
using DistLab2.Core.Interfaces;
using DistLab2.Core.Services;
using DistLab2.Data;
using DistLab2.Persistence;
using DistLab2.Persistence.Interfaces;
using DistLab2.Persistence.Repositories;
using DistLab2.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DistLab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));
            builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbConnection")));

            builder.Services.AddDefaultIdentity<DistUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()  // för admin
                .AddEntityFrameworkStores<IdentityContext>();


            builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
            builder.Services.AddScoped<IBidRepository, BidRepository>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAuctionPersistence, AuctionPersistence>();
            builder.Services.AddScoped<IAuctionService, AuctionService>();

            // add auto mapper scanning (requires AutoMapper package)
            builder.Services.AddAutoMapper(typeof(Program));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Ensure Admin role
            using (var scope = app.Services.CreateScope())
            {
                EnsureAdminRoleForExistingUser(scope.ServiceProvider).Wait();
                //EnsureAdminRole(scope.ServiceProvider).Wait();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); ;

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
            app.Run();
        }

        public static async Task EnsureAdminRole(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var adminUser = new IdentityUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
            };

            var result = await userManager.CreateAsync(adminUser, "YourStrongPasswordHere!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Administratör");
            }

        }

        public static async Task EnsureAdminRoleForExistingUser(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DistUser>>();

            // Säkerställ att "Admin"-rollen existerar
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Hitta en befintlig användare
            var existingUser = await userManager.FindByNameAsync("agge@hotmail.com");
            if (existingUser != null)
            {
                // Lägg till användaren till "Admin"-rollen
                if (!await userManager.IsInRoleAsync(existingUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(existingUser, "Admin");
                }
            }
        }


    }
}