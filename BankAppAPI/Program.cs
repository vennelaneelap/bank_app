using BankAppAPI.Repositories;
using BankAppAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddSingleton<CustomerRepository>();
builder.Services.AddSingleton<CustomerService>();

var app = builder.Build();

app.MapControllers();

app.Run();