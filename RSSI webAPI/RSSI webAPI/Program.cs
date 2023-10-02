using RSSI_webAPI.Repositories;
using RSSI_webAPI.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISatelliteDataRepository, SatelliteDataRepository>();

var app = builder.Build();

// HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
