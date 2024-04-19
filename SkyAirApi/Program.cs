using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SkyAirApi.Data;
using SkyAirApi.Helpers;
using SkyAirApi.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ISkyAirRepository, SkyAirRepository>();
string connectionString =
    builder.Configuration.GetConnectionString("SkyAirAzure");
builder.Services.AddDbContext<SkyAirContext>
    (options => options.UseSqlServer(connectionString));

HelperActionServicesOAuth helper = new HelperActionServicesOAuth(builder.Configuration);
builder.Services.AddSingleton<HelperActionServicesOAuth>(helper);

builder.Services.AddAuthentication
    (helper.GetAuthenticateSchema())
    .AddJwtBearer(helper.GetJwtBearerOptions());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api SkyAir Cristopher Jmnz",
        Description = "Api de desarrollo de aerolínea SkyAir ",
        Contact = new OpenApiContact
        {
            Name = "Cristopher Jimenez",
            Email = "crisjimenez19@gmail.com"
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(
        url: "/swagger/v1/swagger.json",
        name: "Api v1"
        );
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
