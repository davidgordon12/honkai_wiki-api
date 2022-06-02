using honkai_wiki_api.Data;
using honkai_wiki_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace honkai_wiki_api.Services
{
    public class ValkyrieService
    {
        SqlCommand command;
        SqlDataReader reader;
        public async Task<JsonResult> GetValkyriesAsync()
        {
            HonkaiContext context = new HonkaiContext();
            List<Valkyrie> valkyries = new();
            command = new SqlCommand("SELECT * FROM Valkyries", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                while(reader.Read())
                {
                    valkyries.Add(new Valkyrie
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Image = reader.GetString(3),
                        Weapon = reader.GetInt32(4)
                    });
                }

                ctx.Close();

                return new JsonResult(valkyries);
            }
        }

        public async Task<JsonResult> GetValkyrieAsync(int id)
        {
            HonkaiContext context = new HonkaiContext();
            command = new SqlCommand($"SELECT Name, Description, Image FROM Valkyries WHERE id = '{id}'", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                return new JsonResult(new Valkyrie
                {
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(3),
                    Weapon = reader.GetInt32(4)
                });
            }
        }
    }
}
