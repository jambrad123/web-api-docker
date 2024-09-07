using Microsoft.EntityFrameworkCore;
using Pets;
using Pets.Entities;
using Pets.Repositories;
using Pets.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IOwnerInfoService, OwnerInfoService>();
builder.Services.AddScoped<IOwnerInfoRepository, OwnerInfoRepository>();
builder.Services.AddSingleton<DataStore>();

builder.Services.AddDbContext<OwnerInfoContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("PetDbConnectionString")), ServiceLifetime.Scoped);


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
