﻿using honkai_wiki_api.Data;
using honkai_wiki_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace honkai_wiki_api.Services
{
    public class ValkyrieService : IHonkaiService
    {
        SqlCommand command;
        SqlDataReader reader;

        public async Task<JsonResult> GetAsync()
        {
            HonkaiContext context = new HonkaiContext();
            List<Valkyrie> valkyries = new();

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();
                command = new SqlCommand("SELECT * FROM Valkyries", context.sqlConnection);

                var task = await Task.Run(async () =>
                    reader = await command.ExecuteReaderAsync()
                );

                while(await reader.ReadAsync())
                {
                    valkyries.Add(new Valkyrie
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Image = reader.GetString(3)
                    });
                }

                ctx.Close();

                return new JsonResult(valkyries);
            }
        }

        public async Task<JsonResult> GetAsync(int id)
        {
            HonkaiContext context = new HonkaiContext();
            command = new SqlCommand($"SELECT * FROM Valkyries WHERE id = '{id}'", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                ctx.Open();

                reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();

                return new JsonResult(new Valkyrie
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Image = reader.GetString(3)
                });
            }
        }
    }
}
