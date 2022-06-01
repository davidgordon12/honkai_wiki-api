namespace honkai_wiki_api.Models
{
    public class Battlesuit
    {
        public Valkyrie Valkyrie { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Features { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
