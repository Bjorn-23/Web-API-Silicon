using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Web_API_Silicon.Filters;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("CoursesSqlServer"));
});

builder.Services.AddCors(x =>
{
    x.AddPolicy("CustomOriginPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7088")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
    x.AddPolicy("InternalPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:7034")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web-API-Silicon", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
    {
        Description = "API Key Authentication",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Query,
        Name = "key"
    }) ;
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddScoped<SubscriptionRepository>();
builder.Services.AddScoped<SubscriptionService>();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseService>();

var app = builder.Build();

app.UseCors(policy =>
{
    policy.WithOrigins("CustomOriginPolicy");
    policy.WithOrigins("InternalPolicy");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web-Api-Silicon v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
