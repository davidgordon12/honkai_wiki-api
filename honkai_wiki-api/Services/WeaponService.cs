using honkai_wiki_api.Data;
using honkai_wiki_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace honkai_wiki_api.Services
{
    public class WeaponService : IHonkaiService
    {
        SqlCommand command;
        SqlDataReader reader;

        public async Task<JsonResult> GetAsync()
        {
            HonkaiContext context = new HonkaiContext();
            List<Weapon> weapons = new();

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                command = new SqlCommand("SELECT * FROM Weapons", context.sqlConnection);

                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                while(await reader.ReadAsync())
                {
                    weapons.Add(new Weapon
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Image = reader.GetString(3),
                        Type = reader.GetString(4),
                        Atk = reader.GetFloat(5),
                        Crt = reader.GetFloat(6)
                    });
                }

                ctx.Close();

                return new JsonResult(weapons);
            }
        }

        public async Task<JsonResult> GetAsync(int id)
        {
            HonkaiContext context = new HonkaiContext();
            command = new SqlCommand($"SELECT * FROM Weapons WHERE id = '{id}'", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();

                reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return new JsonResult(new Weapon
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(3),
                    Type = reader.GetString(4),
                    Atk = reader.GetFloat(5),
                    Crt = reader.GetFloat(6)
                });
            }
        }
    }
}
