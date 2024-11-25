using Microsoft.EntityFrameworkCore;
using Net8.Middleware;
using Net8.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
try
{
    Log.Information("Startup web Application");

    builder.Host.UseSerilog();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<DingContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    
    var app = builder.Build();

    app.UseMiddleware<RequestMiddleware>();
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
}
catch (Exception)
{
    throw;
}
finally
{
    // �N�̫�Ѿl�� Log �g�J�� Sinks �h�I
    Log.Information("Close web Application");
    Log.CloseAndFlush();
}