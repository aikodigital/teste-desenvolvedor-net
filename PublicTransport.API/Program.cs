using Microsoft.EntityFrameworkCore;
using PublicTransport.API.Extensions;
using PublicTransport.API.Mappers;
using PublicTransport.API.Persistence;
using PublicTransport.API.Repositories;
using PublicTransport.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("PublicTransportCs");

builder.Services.AddDbContext<PublicTransportDbContext>(o => o.UseSqlServer(connectionString));

//builder.Services.AddDbContext<PublicTransportDbContext>(o => o.UseSqlServer("server=localhost;database=public_transport;user=root;password=password"));

builder.Services.AddRepositoryServices();

builder.Services.AddAutoMapper(typeof(LineProfile));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
