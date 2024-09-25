using Microsoft.EntityFrameworkCore;
using Models.ConnectionDB;
using Models.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddTransient<AdministradorMG>(); 
builder.Services.AddTransient<ClienteMG>();
builder.Services.AddTransient<CanchaMG>();
builder.Services.AddTransient<DeporteMG>();
builder.Services.AddTransient<ElementoMG>();
builder.Services.AddTransient<ElementosCanchaMG>();
builder.Services.AddTransient<TurnosMG>();



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
