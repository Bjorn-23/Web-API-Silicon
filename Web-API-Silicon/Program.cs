using Infrastructure.Repositories;
using Infrastructure.Services;
using Web_API_Silicon.Configurations;
using Web_API_Silicon.Helpers;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterJwt(builder.Configuration);
builder.Services.RegisterCors(builder.Configuration);
builder.Services.RegisterSwaggerGen(builder.Configuration);

builder.Services.AddScoped<StatusCodeSelector>(); // using in contacts and subscriptions controller.

builder.Services.AddScoped<SubscriptionRepository>();
builder.Services.AddScoped<SubscriptionService>();

builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<ContactService>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

//--------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------

var app = builder.Build();

app.UseCors(policy =>
{
    policy.WithOrigins("CustomOriginPolicy");
    policy.WithOrigins("InternalPolicy");
});
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web-Api-Silicon v1");
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
