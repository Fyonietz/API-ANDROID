using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Linq;  // <-- Needed for Zip

namespace ServeList.Makanan
{
    public class Makanan
    {
        public string Nama_Makanan { get; set; }
        public long Harga_Makanan { get; set; }
    }

    public class DaftarMakanan
    {
        public string[] Nama = { "Ayam Geprek", "Nasi Goreng" };
        public long[] Harga = { 10_000, 5_000 };
    }

    public static class MakananEndpoints
    {
        public static void MakananRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/makanan/lists", () =>
            {
                var daftar = new DaftarMakanan();
                var listMakanan = daftar.Nama.Zip(daftar.Harga, (nama, harga) => new Makanan
                {
                    Nama_Makanan = nama,
                    Harga_Makanan = harga
                }).ToList();

                return Results.Json(listMakanan);
            });

            app.MapPost("api/makanan/tambah",()=>{
              

            });
        }
    }
}

