using MarketHunter.WebAPI.Data;
using MarketHunter.WebAPI.Interfaces;
using MarketHunter.WebAPI.Models;
using MarketHunter.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGenericCrudMethods<InstrumentMaster>, InstrumentMasterService>();
builder.Services.AddScoped<IGenericCrudMethods<TimeFrameMaster>, TimeFrameMasterService>();
builder.Services.AddScoped<IGenericCrudMethods<TradeStatusMaster>, TradeStatusMasterService>();
builder.Services.AddScoped<IGenericCrudMethods<TradeDirection>, TradeDirectionService>();
builder.Services.AddScoped<IGenericCrudMethods<StrategyMaster>, StrategyMasterService>();
builder.Services.AddScoped<IGenericCrudMethods<TradeMaster>, TradeMasterService>();
builder.Services.AddScoped<IGenericCrudMethods<TradeDetail>, TradeDetailService>();

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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
