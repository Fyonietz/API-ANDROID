using Microsoft.AspNetCore.Builder;
using ServeList.Admin;
using ServeList.Makanan;
using ServeList.Pesanan;
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

var app = builder.Build();

// Use the CORS policy
app.UseCors("AllowAll");

// Minimal Hello World endpoint
app.MapGet("/nama", () =>
  Results.Json(new {
      depan="Bodi",
      belakang="Sumatra"
    })
   );
// Daftar Routes 

app.MapAdminRoutes();
app.MakananRoutes();
app.PesananRoutes();
app.Run();

