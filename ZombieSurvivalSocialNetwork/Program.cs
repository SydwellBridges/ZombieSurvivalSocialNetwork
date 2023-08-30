using Microsoft.EntityFrameworkCore;
using ZombieSurvivalSocialNetwork.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/// <summary>
/// Adds the database context for the Zombie Survival API using an in-memory database.
/// </summary>
builder.Services.AddDbContext<ZombieSurvivalDbContext>(options =>
    options.UseInMemoryDatabase("ZombieSurvivalDb"));

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
