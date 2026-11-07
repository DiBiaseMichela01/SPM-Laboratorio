using SPM.Tourism.Api.Data;
using Microsoft.EntityFrameworkCore;
using SPM.Tourism.Api.Services;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("ReactFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
