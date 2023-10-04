using MarketData.Application;
using MarketData.Application.Trades.Queries.GetLatestInstrumentClosePrices;
using MarketData.Infrastructure.Trades;
using MarketData.Infrastructure.Trades.Contracts;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AppliationRegistertion();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();

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
