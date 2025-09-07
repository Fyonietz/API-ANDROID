using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;  // <-- Needed for Zip

namespace ServeList.Pesanan{
    public class Pesanan{
      public int id_pesanan{get;set;}
      public string? nama_pesanan{get;set;}
      public string? status_pesanan{get;set;}
      public string? waktu_pesanan{get;set;}
      public long total_pesanan{get;set;}
      public int id_pembeli{get;set;}
      public int id_makanan{get;set;}
    }
  public static class PesananEndopoints{
    public static void PesananRoutes(this IEndpointRouteBuilder app){
        app.MapGet("/api/pesanan/daftar",()=>{
            var pesanan = new Pesanan{
              id_pesanan = 1,
              nama_pesanan="Ikan Goreng",
              status_pesanan="Dimasak",
              waktu_pesanan="07-09-2025",
              total_pesanan=25_000,
              id_pembeli=2,
              id_makanan=3
            };
            return Results.Json(pesanan);
        });
    }
  }
}
