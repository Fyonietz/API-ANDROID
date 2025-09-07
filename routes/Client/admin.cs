using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ServeList.Admin
{
    public class AdminData
    {
        public string Nama { get; set; }
        public string Password { get; set; }
    }

    public static class AdminRouteEndpoints
    {
        public static void MapAdminRoutes(this IEndpointRouteBuilder app)
        {
            // Respond to GET /admin
            app.MapGet("/admin", () =>
            {
                var admin = new AdminData
                {
                    Nama = "Bodi",
                    Password = "Secret-123"  
                };

                return Results.Json(admin);
            });
        }
    }
}

