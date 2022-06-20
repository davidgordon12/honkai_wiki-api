using honkai_wiki_api.Data;
using honkai_wiki_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace honkai_wiki_api.Services
{
    public class BattlesuitService : IHonkaiService
    {
        SqlCommand command;
        SqlDataReader reader;

        public async Task<JsonResult> GetAsync()
        {
            HonkaiContext context = new HonkaiContext();
            List<Battlesuit> battlesuits = new();

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                command = new SqlCommand("SELECT * FROM Battlesuits", context.sqlConnection);

                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                while(await reader.ReadAsync())
                {
                    battlesuits.Add(new Battlesuit
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Image = reader.GetString(2),
                        Type = reader.GetString(3),
                        Weapon = reader.GetInt32(4),
                        Valkyrie = reader.GetInt32(5)
                    });
                }

                ctx.Close();

                return new JsonResult(battlesuits);
            }
        }

        public async Task<JsonResult> GetAsync(int id)
        {
            HonkaiContext context = new HonkaiContext();
            command = new SqlCommand($"SELECT * FROM Battlesuits WHERE id = '{id}'", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();

                reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return new JsonResult(new Battlesuit
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Image = reader.GetString(2),
                    Type = reader.GetString(3),
                    Weapon = reader.GetInt32(4),
                    Valkyrie = reader.GetInt32(5)
                });
            }
        }
    }
}
