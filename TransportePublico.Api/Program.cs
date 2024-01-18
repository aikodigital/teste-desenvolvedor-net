using System.Reflection;
using System.Text.Json.Serialization;
using TransportePublico.Domain;
using TransportePublico.Infra;
using TransportePublico.Infra.DI;

IConfiguration _configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);

var currentAssembly = Assembly.GetAssembly(typeof(Program))!;

var configuracao = new Configuracao
{
    Assemblies = currentAssembly
        .GetReferencedAssemblies()
        .Where(e => e.FullName.StartsWith("TransportePublico"))
        .Select(Assembly.Load)
        .Union(new[] { currentAssembly })
        .ToList()
};
builder.Services.AddSingleton<IConfiguracao>(configuracao);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});
builder.Services.AddLibs(configuracao);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPostgres(_configuration);
builder.Services.AddRepositories();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransportePublico API V1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }