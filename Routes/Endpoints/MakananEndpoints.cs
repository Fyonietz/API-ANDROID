

namespace ServeList.Makanan{

  public static class MakananEndpoints{
    public static void MakananRoutes(this IEndpointRouteBuilder app){
      app.MapGet("/api/makanan/daftar",(MakananServices services)=>{
          var all =services.GetAll();
          return Results.Json(all);
      });

      app.MapPost("/api/makanan/tambah",(Makanan makanan,MakananServices services)=>{
          
          var Makanan_New = services.Add(makanan);
          makanan.id = Makanan_New;

          return Results.Created($"/api/makanan/tambah/{Makanan_New}",makanan);
      });

      app.MapPost("/api/makanan/hapus",(Makanan makanan,MakananServices services)=>{
         var Makanan_Del = services.Delete(makanan);
         makanan.id = Makanan_Del;

         return "Deleted Success";
      });
    }
  }

}//End Of namespace
