using KCIBES_HFT_2021221.Data;
using KCIBES_HFT_2021221.Endpoint.Services;
using KCIBES_HFT_2021221.Logic;
using KCIBES_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Endpoint
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IDriverLogic, DriverLogic>();
            services.AddTransient<ITeamLogic, TeamLogic>();
            services.AddTransient<IMotorLogic, MotorLogic>();
            services.AddTransient<IDriverRepository, DriverRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IMotorRepository, MotorRepository>();
            services.AddTransient<F1DbContext, F1DbContext>();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:48100"));
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
