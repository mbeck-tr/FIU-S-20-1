using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            #region Standarddokumentensuche...
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("index.html");
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //defaultFilesOptions.DefaultFileNames.Add("homepage.html");

            //app.UseDefaultFiles(defaultFilesOptions); //Muss vor UseStaticFiles in der Pipeline stehen!!!
            #endregion

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            //app.UseMvc();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute("department", "{controller=Department}/{action=List}");
            });


            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing response");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("MW3: Hello from 3. Middleware");
                logger.LogInformation("MW3: Request handled and response produced");
                await next();
                logger.LogInformation("MW3: Outgoing response");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW4: Hello from 4. Middleware");
                logger.LogInformation("MW4: Request handled and response produced");
            });
        }
    }
}
