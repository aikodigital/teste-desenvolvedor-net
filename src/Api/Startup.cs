using Api.Dependency;
using Data.Context;
using Data.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
                        
            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });

            services.InjectionService(Configuration);

            services.AddDbContext<AikoContext>(options => {
                options.UseNpgsql(Configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration.GetSection("SwaggerGenConfig:Version").Value, new OpenApiInfo 
                { 
                    Title = Configuration.GetSection("SwaggerGenConfig:Name").Value, 
                    Version = Configuration.GetSection("SwaggerGenConfig:Version").Value,
                    Contact = new OpenApiContact
                    {
                        Email = Configuration.GetSection("SwaggerGenConfig:Email").Value,
                        Name = Configuration.GetSection("SwaggerGenConfig:Development").Value,                        
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration.GetSection("SwaggerGenConfig:Name").Value));
            }

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                AikoContext db = serviceScope.ServiceProvider.GetService<AikoContext>();
                db.Database.Migrate();
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
