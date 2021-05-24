using EnterprisesX.API.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EnterprisesX.API
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

            #region Swagger Gen

            services.AddSwaggerGen((s) =>
            {
                s.SwaggerDoc(Constants.API_VERSION_V1, new OpenApiInfo
                {
                    Title = "EnterprisesX Permission API",
                    Description = "EnterprisesX Permission Backend API Service",
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    },
                    Version = Constants.API_VERSION_V1,
                    Contact = new OpenApiContact
                    {

                        Email = "zabala.melendez@gmail.com",
                        Name = "Ramon A. Zabala",
                        Url = new Uri("https://github.com/ZabalaMelendez")
                    }

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c => {
                c.SerializeAsV2 = true;
               
            });

            app.UseSwaggerUI(ui => {

                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "EnterprisesX Permission API V1");
                ui.RoutePrefix = string.Empty;
             
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
