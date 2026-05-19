using UserManagementAPI.Middleware;
using UserManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();
