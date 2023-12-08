using Dapper;
using LocalDatabaseApp.Interfaces;
using LocalDatabaseApp.Models;
using Npgsql;

namespace LocalDatabaseApp.Repositories
{
    public class DarbuotojasRepository : IDarbuotojasRepository
    {
        public IEnumerable<Darbuotojas> GetDarbuotojai()
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=Moliugas5;Host=localhost;Port=5432;Database=Database1201;"))
            {
                return connection.Query<Darbuotojas>("SELECT * FROM darbuotojas").ToList();
            }
        }

        public int InsertDarbuotojas(string name, string id, string lastName)
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=Moliugas5;Host=localhost;Port=5432;Database=Database1201;"))
            {
                string sql = $"INSERT INTO Darbuotojas (asmenskodas, Vardas, Pavarde) VALUES (@id, @name, @lastName)";
                var queryArguments = new
                {
                    name = name,
                    id = id,
                    lastName = lastName
                };

                return connection.Execute(sql, queryArguments);
            }
        }

        public int ModifyDarbuotojas(string name, string id, string lastName)
        {
            using (var connection = new NpgsqlConnection("User ID=postgres;Password=Moliugas5;Host=localhost;Port=5432;Database=Database1201;"))
            {
                string sql = $"UPDATE Darbuotojas SET Vardas = @name, Pavarde = @lastName WHERE asmenskodas = @id";
                var queryArguments = new
                {
                    name = name,
                    id = id,
                    lastName = lastName
                };

                return connection.Execute(sql, queryArguments);
            }
        }
    }
}
