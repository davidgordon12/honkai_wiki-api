using Microsoft.AspNetCore.Mvc;

namespace honkai_wiki_api.Services
{
    public interface IHonkaiService
    {
        Task<JsonResult> GetAsync();
        Task<JsonResult> GetAsync(int id);
    }
}