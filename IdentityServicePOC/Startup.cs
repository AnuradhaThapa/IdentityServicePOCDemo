using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.Model;
using IdentityService.Infrastructure.Models;
using IdentityService.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace IdentityServicePOC
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        private IConfiguration _config;
        /// <summary>
        /// Startup Constructor
        /// </summary>
        /// <param name="config"></param>
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AMDBContext>(options => options.UseSqlServer(_config.GetConnectionString("AMDBConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ILog, Log>();
            services.AddControllers();
            services.AddHttpClient();
            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen(x=> {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Identity Service API",
                    Description = "Identity Service POC"
                });
                x.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "IdentityServiceAPI.xml"));
            });
            services.AddAutoMapper(typeof(UserProfile));
            
            
        }


        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");
                c.RoutePrefix = string.Empty;
            });
            
        }
    }
}
