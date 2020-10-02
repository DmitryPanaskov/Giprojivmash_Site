using AutoMapper;
using Giprojivmash.BLL.Interfaces;
using Giprojivmash.BLL.Services;
using Giprojivmash.DAL.Context;
using Giprojivmash.DAL.Entities;
using Giprojivmash.DAL.Interfaces;
using Giprojivmash.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            string connectionString = _configuration.GetConnectionString("GiprojivmashConnection");
            services.AddDbContext<GiprojivmashContext>(options => options.UseMySQL(connectionString, m => m.MigrationsAssembly("Giprojivmash.BLL")));

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactDataService, ContactDataService>();
            services.AddScoped<IVacancyService, VacancyService>();

            services.AddScoped<IRepository<ContactEntity>, GenericRepository<ContactEntity>>();
            services.AddScoped<IRepository<ContactDataEntity>, GenericRepository<ContactDataEntity>>();
            services.AddScoped<IRepository<VacancyEntity>, GenericRepository<VacancyEntity>>();

            services.AddIdentity<UserEntity, IdentityRole>()
               .AddEntityFrameworkStores<GiprojivmashContext>();

            services.AddHttpContextAccessor();

            services.AddControllersWithViews();

            var config = new MapperConfiguration(c =>
            {
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

            app.UseAuthentication();
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
