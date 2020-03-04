using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Application;
using EquipmentManagement.Application.Database.Commands;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Infrastructura;
using EquipmentManagement.Infrastructura.Commands.Contracts;
using EquipmentManagement.Security;

namespace EquipmentManagement.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IServiceProvider ServiceProvider { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddInfrastructura();
            services.AddCommandsAndQueries(typeof(Initializer).Assembly);

            services.AddDbContext<DataContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSecurity();

            ServiceProvider = services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            ServiceProvider
                .GetRequiredService<ICommandDispatcher>()
                .Execute<CreateDatabaseCommand>();

            ServiceProvider
                .GetRequiredService<ICommandDispatcher>()
                .Execute<InitDataCommand>();
        }
    }
}