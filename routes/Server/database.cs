using Microsoft.Data.Sqlite;

public class DatabaseService{
  private readonly string _connectionstring;

  public DatabaseService(string dbPath){
    _connectionstring = $"Data Source={dbPath}";
  }

}
