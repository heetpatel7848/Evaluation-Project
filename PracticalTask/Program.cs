using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Models;
using PracticalTask.Models.Interface;
using PracticalTask.Models.Repository;
using PracticalTask.Services.Interface;
using PracticalTask.Services.Mapper;
using PracticalTask.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<PracticalTaskContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PracticalTaskConnStr"));
});

#region Dependency Injection
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IPriceChangeService , PriceChangeService>();
builder.Services.AddScoped<IPriceChangeRepository, PriceChangeRepository>();
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
