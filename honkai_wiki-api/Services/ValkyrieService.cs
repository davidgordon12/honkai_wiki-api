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
                        Image = reader.GetString(2),
                        Weapon = reader.GetInt32(3),
                        Description = reader.GetString(4)
                    });
                }

                ctx.Close();

                return new JsonResult(valkyries);
            }
        }
    }
}
