using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UtentesService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do servidor Kestrel - apenas HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5002); // Porta HTTP
});

// Configura��o do contexto da base de dados (InMemory)
builder.Services.AddDbContext<UtentesContext>(opt =>
    opt.UseInMemoryDatabase("UtentesDB"));

// Servi�os da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger ativo apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rota raiz amig�vel (verifica se o servi�o est� ativo)
app.MapGet("/", () => "Servi�o Utentes ativo!");

// Mapeamento dos controladores
app.MapControllers();

// Inicia a aplica��o
app.Run();
