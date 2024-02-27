using AutoMapper;
using Data.AutoMapperProfiles;
using Data.Context;
using Data.Repository;
using Domain.IRepository;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.DataContext;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Data.IoC
{
    public static class DataInjection
    {
        public static void InjectionService(this IServiceCollection services)
        {
            services.AddScoped<IDataContext>(provider => provider.GetService<AikoContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IStopRepository, StopRepository>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehiclePositionRepository, VehiclePositionRepository>();
        }
        
        public static IServiceCollection AddAutoMapperInjector(this IServiceCollection services)
        {
            MapperConfiguration mapperConfig = new MapperConfiguration(mp =>
            {
                mp.AddProfile(new StopProfile());
                mp.AddProfile(new LineProfile());
                mp.AddProfile(new VehicleProfile());
                mp.AddProfile(new VehiclePositionProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;

        }


    }
}
