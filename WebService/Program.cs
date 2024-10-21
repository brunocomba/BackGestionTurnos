using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.ConnectionDB;
using Models.Managers;
using System.Text;
using WebService;

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




// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()       // Permite todas las solicitudes de cualquier origen
               .AllowAnyMethod()       // Permite cualquier método (GET, POST, etc.)
               .AllowAnyHeader();      // Permite cualquier encabezado
    });
});


// Evitar los ciclos
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// JWT

var key = builder.Configuration.GetValue<string>("Jwt:key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false, // no  necesitamos validar desde donde esta validadndo el usurio
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero


    };
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

// Add authentication middleware

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
