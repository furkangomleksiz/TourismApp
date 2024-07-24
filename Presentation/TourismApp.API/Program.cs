using Microsoft.EntityFrameworkCore;
using TourismApp.Application.Commands;
using TourismApp.Domain.Interfaces;
using TourismApp.Infrastructure.Repositories;
using TourismApp.Persistence.Data;
using TourismApp.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TourContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTourCommandHandler).Assembly));
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITourProductRepository, TourProductRepository>();
builder.Services.AddScoped<IPaxRepository, PaxRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

