var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

// Habilita CORS
builder.Services.AddCors();

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin() // Reemplaza con el dominio de tu sitio web
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseAuthorization();

app.Run();
