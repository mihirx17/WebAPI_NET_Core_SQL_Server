using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProgramList_LTIMindtree__Test.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<pgm_Program_DetailContext>(Options=>
Options.UseSqlServer("Data Source=MIHIR\\SQLSERVER_2;Initial Catalog=ProgramList_LTIMindtree;Integrated Security=True;Trust Server Certificate=True")

);

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
