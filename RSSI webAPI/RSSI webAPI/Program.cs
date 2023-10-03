
using RSSI_webAPI.Extensions;
using RSSI_webAPI.Repositories;
using RSSI_webAPI.Repositories.Contracts;
using RSSI_webAPI.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(x => {
    x.AddSecurityDefinition("StaticApiKey",new OpenApiSecurityScheme { 
        Description = "The Api key to access the controllers",
        Type = SecuritySchemeType.ApiKey,
        Name = "x-api-key",
        In = ParameterLocation.Header,
        Scheme = "StaticApiKeyAuthorizationScheme",
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Id = "StaticApiKey",
            Type = ReferenceType.SecurityScheme,
        },
        In = ParameterLocation.Header,
    };

    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, new List<string>() }
    };

    x.AddSecurityRequirement(requirement);
});

builder.Services.AddScoped<ISatelliteDataRepository, SatelliteDataRepository>();
builder.Services.AddScoped<IEarthDataRepository,EarthDataRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfiguration));
builder.Services.AddScoped<AuthFilter>();

var app = builder.Build();


// Check appsettings.json
string? client = builder.Configuration.GetSection("Urls").GetValue<string>("Client");
string? sclient = builder.Configuration.GetSection("Urls").GetValue<string>("Secureclient");

// Configure CORS policy
app.UseCors(options => 
    options.AllowAnyOrigin()
    // .WithOrigins(client, sclient)
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

// HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
