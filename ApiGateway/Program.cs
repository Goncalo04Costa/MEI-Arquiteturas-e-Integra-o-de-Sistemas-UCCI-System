using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// =======================================================
// Configure Kestrel server to a fixed port
// =======================================================
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // API Gateway HTTP Port
});

// =======================================================
// Load Ocelot configuration from ocelot.json
// Downstream: where to redirect
// Upstream: path received
// =======================================================
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// =======================================================
// Add Ocelot services to DI container
// =======================================================
builder.Services.AddOcelot(builder.Configuration);

// Optional: allow any origin for testing
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// =======================================================
// Enable routing & CORS
// =======================================================
app.UseRouting();
app.UseCors("CorsPolicy");

// =======================================================
// Use Ocelot middleware to forward requests
// =======================================================
await app.UseOcelot();

// =======================================================
// Run the API Gateway
// =======================================================
app.Run();
