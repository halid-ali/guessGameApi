using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GuessGameApi.Repository;
using GuessGameApi.Repository.MySqlRepo;
using GuessGameApi.Repository.SqlRepo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace GuessGameApi
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
            services.AddControllers().AddNewtonsoftJson(
                s =>
                {
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
            );
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddTransient<MySqlGuessRepository>(_ => new MySqlGuessRepository());
            services.AddScoped<IGuessRepository, MySqlGuessRepository>();
            
            // services.AddDbContext<SqlGuessContext>(
            //     opt => opt.UseSqlServer(Configuration.GetConnectionString("LocalhostConnection")));
            //services.AddScoped<IGuessRepository, SqlGuessRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
