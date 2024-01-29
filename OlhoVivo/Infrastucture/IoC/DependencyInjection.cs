
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlhoVivo.Core.Application.Interfaces;
using OlhoVivo.Core.Application.Mappings;
using OlhoVivo.Core.Application.Services;
using OlhoVivo.Core.Domain.Account;
using OlhoVivo.Core.Domain.Interfaces;
using OlhoVivo.Infra.Data;
using OlhoVivo.Infra.Data.Context;
using OlhoVivo.Infra.Data.Identity;
using OlhoVivo.Infra.Data.Repositories;

namespace OlhoVivo.Infra.IoC;

public static class DependencyInjection
{
   public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Database
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        #endregion

        #region Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        #endregion

        #region Redirecionamento Login
        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");
        #endregion

        #region Services
        services.AddScoped<ILineRepository, LineRepository>();
        services.AddScoped<IStopRepository, StopRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();

        services.AddScoped<ILineService, LineService>();
        services.AddScoped<IStopService, StopService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IVehiclePositionService, VehiclePositionService>();
        #endregion

        #region Auth
        services.AddScoped<IAuthenticate, AuthenticateService>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        #endregion

        #region Auto Mapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        #endregion

        return services;
    }
}