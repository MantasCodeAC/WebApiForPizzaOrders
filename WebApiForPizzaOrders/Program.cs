using Microsoft.EntityFrameworkCore;
using WebApiForPizzaOrders.Repository.Data;
using WebApiForPizzaOrders.Repository.Repositories;
using WebApiForPizzaOrders.Services.Interfaces;
using WebApiForPizzaOrders.Services.Services;
using WebApplicationForPizzaOrders.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApiForPizzaOrdersDbContext>(options => options.UseInMemoryDatabase("PizzaOrdersDb"));
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
//builder.Services.AddScoped<IToppingRepository, ToppingRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// Add services to the container.

builder.Services.AddControllers();
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
