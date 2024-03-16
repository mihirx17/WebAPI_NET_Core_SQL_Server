using Advance_SQL_SERVER_with_API.Data;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentDBcontext>(options =>
    options.UseSqlServer("Data Source=MIHIR\\SQLSERVER_2;Initial Catalog=Testing_Random;Integrated Security=True;Trust Server Certificate=True"));

Log.Logger = new LoggerConfiguration().
    MinimumLevel.Information().
    WriteTo.File("Log/log.txt",rollingInterval:RollingInterval.Minute).CreateLogger();
// Add services to the container.

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
