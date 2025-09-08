using Microsoft.AspNetCore.Builder;
using ServeList.Makanan;
var builder = WebApplication.CreateBuilder(args);

// Enable CORS for all origins (for development only)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Make app listen on all network interfaces (important for LAN access)
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Set DB path
var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Routes", "Server", "data.db");
// Register SQLite-based service
builder.Services.AddSingleton(new MakananServices(dbPath));
var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowAll");

// Minimal Hello World endpoint
app.MapGet("/nama", () =>
  Results.Json(new
  {
      depan = "Bodi",
      belakang = "Sumatra"
  })
   );
// Daftar Routes 

app.MakananRoutes();
app.Run();

