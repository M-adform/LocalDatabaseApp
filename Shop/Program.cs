using Microsoft.EntityFrameworkCore;
using Npgsql;
using Shop.Data;
using Shop.Interfaces;
using Shop.Repositories;
using Shop.Services;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ShopContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ShopContext") ?? throw new InvalidOperationException("Connection string 'ShopContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IShopItemService, ShopItemService>();
builder.Services.AddTransient<IShopItemRepository, ShopItemRepository>();

builder.Services.AddDbContext<ShopContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("postgres") ?? throw new InvalidOperationException("Invalid connection string 'postgres'"));
//string connectionString = builder Configrati

string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString));

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
