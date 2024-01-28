using OlhoVivo.Core.Domain.Account;
using OlhoVivo.Infra.IoC;

#region Services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureAPI(builder.Configuration);

// Ativar autenticacao e validar o token
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
// builder.Services.AddControllers().AddNewtonsoftJson(options => {
//     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
// });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region App

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

SeedUserRoles(app);

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider.GetService<ISeedUserRoleInitial>();

        seed.SeedRoles();
        seed.SeedUsers();
    }
}
#endregion
