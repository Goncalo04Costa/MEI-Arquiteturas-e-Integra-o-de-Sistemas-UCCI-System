using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ConsultasService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5003); // HTTP
});

// Configurar DbContext para PostgreSQL do Neon
builder.Services.AddDbContext<ConsultasContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConsultasDatabase")));

// Adicionar serviços do ASP.NET
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Rota raiz amigável
app.MapGet("/", () => "Serviço Consultas ativo!");

app.MapControllers();
app.Run();
