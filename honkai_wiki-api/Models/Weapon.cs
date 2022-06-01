namespace honkai_wiki.Models
{
    public class Weapon
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Stars { get; set; }
        public int BaseAtk { get; set; }
        public int MaxAtk { get; set; }
        public int BaseCrt { get; set; }
        public int MaxCrt { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
