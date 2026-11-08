using SPM.Tourism.Api.Data;
using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Read the JWT signing key from configuration
string? jwtKey = builder.Configuration["Jwt:Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new InvalidOperationException(
        "JWT signing key is missing from configuration.");
}

// Decode the JWT signing key from Base64
byte[] jwtKeyBytes = Convert.FromBase64String(jwtKey);

// Ensure the signing key is at least 256 bits
if (jwtKeyBytes.Length < 32)
{
    throw new InvalidOperationException(
        "JWT signing key must contain at least 32 bytes.");
}

// Prepare the symmetric key used for JWT signatures
var signingKey = new SymmetricSecurityKey(jwtKeyBytes);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var firstError = context.ModelState.Values
            .SelectMany(value => value.Errors)
            .FirstOrDefault();

        return new BadRequestObjectResult(
            firstError?.ErrorMessage ?? "Invalid registration data.");
    };
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
 options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<JwtTokenService>();

// Configure JWT Bearer authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Validate the JWT signature
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            // Validate the token issuer
            ValidateIssuer = true,
            ValidIssuer = "SPM.Tourism.Api",

            // Validate the intended audience
            ValidateAudience = true,
            ValidAudience = "SPM.Tourism.PWA",

            // Reject expired tokens
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(1)
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("ReactFrontend");

// Identify the user from the JWT token
app.UseAuthentication();

// Check access permissions
app.UseAuthorization();

app.MapControllers();

app.Run();
