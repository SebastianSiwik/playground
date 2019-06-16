using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleService.Data.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BicycleService.Data.Sql.Migrations;
using FluentValidation;
using BicycleService.Api.BindingModels;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using FluentValidation.AspNetCore;
using static BicycleService.Api.BindingModels.EditUser;
using BicycleService.Api.Middlewares;

namespace BicycleService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BicycleServiceDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("BicycleServiceDbContext")));
            services.AddTransient<DatabaseSeed>();
            services.AddScoped<IValidator<EditUser>, EditUserValidator>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            })
            .AddFluentValidation();
            services.AddApiVersioning(o => o.ReportApiVersions = true);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<BicycleServiceDbContext>();
                var databaseSeed = serviceScope.ServiceProvider.GetRequiredService<DatabaseSeed>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                databaseSeed.Seed();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMvc();
        }
    }
}
