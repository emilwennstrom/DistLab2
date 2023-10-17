using DistLab2.Core.Interfaces;
using DistLab2.Core.Repositories;
using DistLab2.Persistence;
using DistLab2.Persistence.MockClasses;
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

            builder.Services.AddScoped<IAuctionRepository, MockAuctionRepository>();

            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapRazorPages();
            app.Run();
        }
    }
}