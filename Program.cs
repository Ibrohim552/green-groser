using FarmConnect.Infrastructure;
using FarmConnect.Infrastructure.Repositories.BuyerRepository.BuyerCommandRepository;
using FarmConnect.Infrastructure.Repositories.BuyerRepository.BuyerReadRepository;
using FarmConnect.Infrastructure.Repositories.FarmerRepository.FarmerCommandRespository;
using FarmConnect.Infrastructure.Repositories.FarmerRepository.FarmerReadRepository;
using FarmConnect.Infrastructure.Repositories.OrderItemRepository.OrderItemCommandRepository;
using FarmConnect.Infrastructure.Repositories.OrderItemRepository.OrderItemReadRepository;
using FarmConnect.Infrastructure.Repositories.OrderRepository.OrderCommandRepository;
using FarmConnect.Infrastructure.Repositories.OrderRepository.OrderReadRepository;
using FarmConnect.Infrastructure.Repositories.ProductRepository.ProductCommandRepository;
using FarmConnect.Infrastructure.Repositories.ProductRepository.ProductReadRepository;
using FarmConnect.Infrastructure.Services.BuyerService;
using FarmConnect.Infrastructure.Services.FarmerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBuyerReadRepository, BuyerReadRepository>();
builder.Services.AddScoped<IBuyerCommandRepository, BuyerCommandRepository>();
builder.Services.AddScoped<IBuyerService, BuyerService>();
builder.Services.AddScoped<IFarmerReadRepository, FarmerReadRepository>();
builder.Services.AddScoped<IFarmerCommandRepository, FarmerCommandRepository>();
builder.Services.AddScoped<IFarmerService, FarmerService>();
builder.Services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
builder.Services.AddScoped<IOrderItemCommandRepository, OrderItemCommandRepository>();
builder.Services.AddScoped<IOrderReadRepository, OrderReadRepository>();
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IProductReadRepository, ProductReadRepository>();
builder.Services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

