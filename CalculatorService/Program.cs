using Microsoft.EntityFrameworkCore;
using TaxCalculator.DataAccess.Context;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.DataAccess.Models;
using TaxCalculator.DataAccess.Repositories;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Managers;
using TaxCalculator.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaxDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TaxDbConnection")));

builder.Services.AddScoped<ITaxCalculatorService, TaxCalculationService>();
builder.Services.AddTransient<ITaxCalculationManager, TaxCalculationManager>();
builder.Services.AddTransient<ITaxRepository<TaxBand>, TaxRepository<TaxBand>>();

var app = builder.Build();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

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
