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


var jwtSettings = new JwtSettings();
builder.Configuration.Bind("Jwt", jwtSettings);

// JWT Authentication configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,          // Verifica el emisor del token
        ValidateAudience = true,        // Verifica el destinatario del token
        ValidateLifetime = true,        // Verifica la expiración del token
        ValidateIssuerSigningKey = true,// Verifica la clave de firma del token
        ValidIssuer = jwtSettings.Issuer,  // Emisor de tu app
        ValidAudiences = jwtSettings.Audiences, // Destinatario esperado (normalmente tu API o frontend)
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gestion-turnos-key-supersegura-202445414815")), // clave secreta
        ClockSkew = TimeSpan.Zero       // Opcional: elimina la tolerancia del reloj para la expiración del token
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
