using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ReservaButacas.Server.Application.Controllers;
using ReservaButacas.Server.Application.Services;
using ReservaButacas.Server.Domain.Interfaces.Repositories;
using ReservaButacas.Server.Domain.Interfaces.Services;
using ReservaButacas.Server.Infrastructure.Data;
using ReservaButacas.Server.Infrastructure.ExternalServices;
using ReservaButacas.Server.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBillboardRepository, BillboardRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBillboardService, BillBoardService>();
builder.Services.AddScoped<ISeatService, SeatService>();


builder.Services.AddScoped<BillboardController>();
builder.Services.AddScoped<BookingController>();
builder.Services.AddScoped<SeatController>();


builder.Services.AddDbContext<ReservasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReservasConnection"))
);
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ReservasContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al aplicar migraciones: " + ex.Message);
    }
}

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandler>();

app.MapFallbackToFile("/index.html");

app.Run();
