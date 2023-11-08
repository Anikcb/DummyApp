using DummyApp.Services;
using DummyApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// https://mohamadlawand.medium.com/middleware-in-asp-net-core-2834479160dd
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();


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
