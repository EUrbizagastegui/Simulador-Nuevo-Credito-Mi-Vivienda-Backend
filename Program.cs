using Microsoft.EntityFrameworkCore;
using NuevoCreditoAPI.NuevoCredito.Domain.Repositories;
using NuevoCreditoAPI.NuevoCredito.Domain.Services;
using NuevoCreditoAPI.NuevoCredito.Mapping;
using NuevoCreditoAPI.NuevoCredito.Persistence.Repositories;
using NuevoCreditoAPI.NuevoCredito.Services;
using NuevoCreditoAPI.Shared.Persistence.Contexts;
using NuevoCreditoAPI.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>( 
    options => options.UseNpgsql(connectionString) // Usar Npgsql para PostgreSQL
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentScheduleRepository, PaymentScheduleRepository>();
builder.Services.AddScoped<IPaymentScheduleService, PaymentScheduleService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => 
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins(
            "http://localhost:5173",
            "https://localhost:5173"
        )
    );

app.MapControllers();

app.Run();