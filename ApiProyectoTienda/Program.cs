using ApiProyectoTienda.Data;
using ApiProyectoTienda.Helpers;
using ApiProyectoTienda.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HelperOAuthToken>();
HelperOAuthToken helper = new HelperOAuthToken(builder.Configuration);
builder.Services.AddAuthentication(helper.GetAuthenticationOptions())
    .AddJwtBearer(helper.GetJwtOptions());

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddTransient<RepositoryArtista>();
builder.Services.AddTransient<RepositoryCliente>();
builder.Services.AddTransient<RepositoryInfoArte>();
builder.Services.AddDbContext<ProyectoTiendaContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api Make-Art 2023",
        Version = "v1",
        Description = "Api para consumir el proyecto de la tienda Make-Art"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Proyecto Make-Art");
    options.RoutePrefix = "";
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
