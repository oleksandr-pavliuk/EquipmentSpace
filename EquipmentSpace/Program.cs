using EquipmentSpace.Auth;
using EquipmentSpace.Models;
using EquipmentSpace.Repository;
using EquipmentSpace.Repository.DBContext;
using EquipmentSpace.Services.ContractService;
using EquipmentSpace.Services.SquareVerificationService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    options.Filters.Add<ApiKeyAttribute>());
builder.Services.AddDbContext<ApplicationContext>(
    options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
       }
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IRepository<Contract>, Repository<Contract>>();
builder.Services.AddScoped<IRepository<Space>, Repository<Space>>();
builder.Services.AddScoped<IRepository<Equipment>, Repository<Equipment>>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<ISquareVerificationService, SquareVerificationService>();
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
