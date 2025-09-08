

namespace ServeList.Makanan{

  public static class MakananEndpoints{
    public static void MakananRoutes(this IEndpointRouteBuilder app){
      app.MapGet("/api/makanan/daftar",(MakananServices services)=>{
          var all =services.GetAll();
          return Results.Json(all);
      });
    }
  }

}//End Of namespace
