using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;
using Giprojivmash.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Giprojivmash.WEB
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            string connectionString = _configuration.GetConnectionString("TicketManagmentConnection");
            services.AddDbContext<GiprojivmashContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IServiceFirstLayerService, ServiceFirstLayerService>();
            services.AddScoped<IServiceSecondLayerService, ServiceSecondLayerService>();
            services.AddScoped<IServiceThirdLayerService, ServiceThirdLayerService>();

            services.AddScoped<IRepository<ServiceFirstLayerEntity>, GenericRepository<ServiceFirstLayerEntity>>();
            services.AddScoped<IRepository<ServiceSecondLayerEntity>, GenericRepository<ServiceSecondLayerEntity>>();
            services.AddScoped<IRepository<ServiceThirdLayerEntity>, GenericRepository<ServiceThirdLayerEntity>>();

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile<Giprojivmash.BLL.Mapper.MappingProfile>();
                c.AddProfile<Giprojivmash.WEB.Mapper.MappingProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<>")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
