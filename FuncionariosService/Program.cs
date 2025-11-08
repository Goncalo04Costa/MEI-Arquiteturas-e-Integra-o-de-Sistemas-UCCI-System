using FuncionariosService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel com porta fixa HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5003); // HTTP
});

// InMemory DB
builder.Services.AddDbContext<FuncionariosContext>(opt => opt.UseInMemoryDatabase("FuncionariosDB"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rota raiz amigável
app.MapGet("/", () => "Serviço Funcionários ativo!");

app.MapControllers();
app.Run();
