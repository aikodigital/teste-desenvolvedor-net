using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace OlhoVivo.Infra.IoC;

public static class DependencyInjectionSwagger
{
    public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo { Title = "OlhoVivo.WebAPI", Version = "v1" });

            config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                //definir configuracoes
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] " +
                "and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });

            config.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                  {
                      new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
            });
        });

        return services;
    }
}
