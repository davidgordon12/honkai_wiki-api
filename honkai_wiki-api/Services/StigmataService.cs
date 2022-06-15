using honkai_wiki_api.Data;
using honkai_wiki_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace honkai_wiki_api.Services
{
    public class StigmataService : IHonkaiService
    {
        SqlCommand command;
        SqlDataReader reader;

        public async Task<JsonResult> GetAsync()
        {
            HonkaiContext context = new HonkaiContext();
            List<Stigmata> stigmatas = new();

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                command = new SqlCommand("SELECT * FROM Stigmatas", context.sqlConnection);

                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                while(await reader.ReadAsync())
                {
                    stigmatas.Add(new Stigmata
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Image = reader.GetString(3),
                        Type = reader.GetString(4)
                    });
                }

                ctx.Close();

                return new JsonResult(stigmatas);
            }
        }

        public async Task<JsonResult> GetAsync(int id)
        {
            HonkaiContext context = new HonkaiContext();
            command = new SqlCommand($"SELECT * FROM Stigmatas WHERE id = '{id}'", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();

                reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return new JsonResult(new Stigmata
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(3),
                    Type = reader.GetString(4)
                });
            }
        }
    }
}
