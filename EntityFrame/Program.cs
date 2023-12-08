using DbUp;
using EntityFrame.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EntityFrameContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection") ?? throw new InvalidOperationException("Connection string 'EntityFrameContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");
builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString));

var upgrader =
     DeployChanges.To
         .PostgresqlDatabase(dbConnectionString)
         .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
         .LogToConsole()
         .Build();

var result = upgrader.PerformUpgrade();

builder.Services.AddHttpClient();

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
