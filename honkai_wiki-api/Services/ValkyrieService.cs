using honkai_wiki_api.Data;
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

            command = new SqlCommand("SELECT * FROM Valkyries", context.sqlConnection);

            using (var ctx = context.sqlConnection)
            {
                var res = await Task.Run(() => ctx);
                return new JsonResult(res);
            }
        }
    }
}
