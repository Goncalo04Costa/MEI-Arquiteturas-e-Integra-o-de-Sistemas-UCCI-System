using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UtentesService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do servidor Kestrel - apenas HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5003); // Porta HTTP
});

// Configuração do contexto da base de dados (InMemory)
builder.Services.AddDbContext<UtentesContext>(opt =>
    opt.UseInMemoryDatabase("UtentesDB"));

// Serviços da API
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

// Rota raiz amigável (verifica se o serviço está ativo)
app.MapGet("/", () => "Serviço Utentes ativo!");

// Mapeamento dos controladores
app.MapControllers();

// Inicia a aplicação
app.Run();
