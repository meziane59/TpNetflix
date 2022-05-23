using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetflixTp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetflixTp
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetflixTp", Version = "v1" });
            });

            const string corsUrlKey = "Security:Cors:Url";

            services.AddCors(cors =>
            {
                string url = this.Configuration[corsUrlKey];

                cors.AddPolicy("AllowAll", o =>
                {
                    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });               
            });

            // Ajout du SERVICE EFCoreDemoContext pour EF
           // services.AddDbContext<masterContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("masterContextConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetflixTp v1"));
            }


            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}