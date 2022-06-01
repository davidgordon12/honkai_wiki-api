using honkai_wiki_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace honkai_wiki_api.Services
{
    public class ValkyrieService
    {
        public async Task<JsonResult> GetValkyriesAsync()
        {
            using(var ctx = new HonkaiContext())
            {
                var res = await Task.Run(() => ctx.Valkyrie.ToList());

                return new JsonResult(res);
            }
        }
    }
}
