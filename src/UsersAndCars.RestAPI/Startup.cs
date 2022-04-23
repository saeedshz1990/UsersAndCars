using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UsersAndCars.Entities;
using UsersAndCars.Infrastructure.Application;
using UsersAndCars.Persistence.EF;
using UsersAndCars.Persistence.EF.Cars;
using UsersAndCars.Persistence.EF.Plaques;
using UsersAndCars.Persistence.EF.Users;
using UsersAndCars.Services.Cars;
using UsersAndCars.Services.Cars.Contracts;
using UsersAndCars.Services.Plaques;
using UsersAndCars.Services.Plaques.Contracts;
using UsersAndCars.Services.Users;
using UsersAndCars.Services.Users.Contracts;

namespace UsersAndCars.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<UsersAndCarsDbContext>
                (_ => _.UseSqlServer(Configuration["ConnectionString"]));

            services.AddScoped<UnitOfWork, EFUnitOfWork>();

            services.AddScoped<UserRepository, EFUserRepository>();
            services.AddScoped<UserService, UserAppService>();

            services.AddScoped<CarRepository, EFCarRepository>();
            services.AddScoped<CarService, CarAppService>();

            services.AddScoped<PlaqueRepository, EFPlaqueRepository>();
            services.AddScoped<PlaqueService, PlaqueAppService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsersAndCars.RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsersAndCars.RestAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
