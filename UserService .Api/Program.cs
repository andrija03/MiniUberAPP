using UserService.Application.Handlers;
using UserService.Domain.Repositories;
using UserService.Infrastructure.Repositories;
using UserService.Application.Services;
using UserService.Infrastructure.Services;
using UserService.Application.Messaging;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));

// Registrujte svoje servise
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDriverService, UserService.Infrastructure.Services.DriverService>();

// Dodajte KafkaProducer i CreateUserService
builder.Services.AddSingleton<KafkaProducer>();
builder.Services.AddScoped<CreateUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
