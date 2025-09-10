using Microsoft.Data.Sqlite;

namespace ServeList.Makanan
{

    public class MakananServices
    {
        private readonly string? _connectionstring;

        public MakananServices(string dbPath)
        {
            _connectionstring = $"Data Source={dbPath}";
        }


        public List<Makanan> GetAll()
        {
            var list = new List<Makanan>();

            using var conn = new SqliteConnection(_connectionstring);

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM makanan";
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Makanan
                {
                    id = reader.GetInt32(0),
                    nama_makanan = reader.GetString(1),
                    harga_makanan = reader.GetInt32(2)
                });
            }

            return list;
        }//End Of GetAll();
        public int Add(Makanan makanan)
        {
            var list = new List<Makanan>();

            using var conn = new SqliteConnection(_connectionstring);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO makanan (nama, harga)
        VALUES ($nama, $harga);
        SELECT last_insert_rowid();
    ";
            cmd.Parameters.AddWithValue("$nama", makanan.nama_makanan);
            cmd.Parameters.AddWithValue("$harga", makanan.harga_makanan);

            var id = (long)cmd.ExecuteScalar();

            return (int)id;

        }//End Of Add();

        public int Delete(Makanan makanan)
        {
            var list = new List<Makanan>();

            using var conn = new SqliteConnection(_connectionstring);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        DELETE FROM makanan
        WHERE id = $id;
        SELECT last_insert_rowid();
    ";
            cmd.Parameters.AddWithValue("$id", makanan.id);

            var id = (long)cmd.ExecuteScalar();

            return (int)id;

        }
    }//End Of MakananServices


}//End Of namespace
