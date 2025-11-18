using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using FuncionariosService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001); // HTTP
    //options.ListenAnyIP(5003, listenOptions => listenOptions.UseHttps()); // HTTPS
});

builder.Services.AddDbContext<FuncionariosContext>(opt => opt.UseInMemoryDatabase("FuncionarioDB"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rota raiz amig�vel
app.MapGet("/", () => "Servi�o Utentes ativo!");

app.MapControllers();
app.Run();
