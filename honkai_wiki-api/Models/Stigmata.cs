namespace honkai_wiki_api.Models
{
    public class Stigmata
    {
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
