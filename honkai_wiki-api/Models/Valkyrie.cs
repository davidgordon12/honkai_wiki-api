namespace honkai_wiki.Models
{
    public class Valkyrie
    {
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public string Description { get; set; }
        public List<Battlesuit> Battlesuits { get; set; }
    }
}
