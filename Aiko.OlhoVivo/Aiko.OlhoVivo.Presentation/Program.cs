using Aiko.OlhoVivo.Application.Shared;
using Aiko.OlhoVivo.Application.UseCase.Linha.AddLine;
using Aiko.OlhoVivo.Presentation.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;

try
{
    var builder = WebApplication.CreateBuilder(args);    
    Log.Information("Getting the motors running...");

    // Add services to the container.

    builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(ApplicationProfile)));
    builder.Services.AddMediator<AddLineCommandHandler>();
    builder.Services.AddContext(builder.Configuration, "DefaultConnection");
    builder.Services.AddScoped();

    builder.Services.AddControllers(delegate (MvcOptions options) { })
        .AddJsonOptions(delegate (JsonOptions options)
    {
        options.JsonSerializerOptions.IncludeFields = true;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Aiko - Olho Vivo",
            Description = "Teste  de desemvolvimento .Net",
            Version = "v1",
            Contact = new() 
            { 
                Name = "Igor Ribeiro",
                Email = "igor_riberi@hotmail.com",
                Url = new Uri("https://www.linkedin.com/in/igorriberi/")
            }
        });
    });

    var app = builder.Build();
    //Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aiko - v1"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

