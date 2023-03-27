using App.Metrics.Formatters.Prometheus;
using BaseApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IJWTService,JWTService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<mycontext>(
    u => { u.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")); }
    );

builder.Services.JwtAuthentication();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
