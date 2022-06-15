namespace honkai_wiki_api.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public float Atk { get; set; }
        public float Crt { get; set; }
    }
}
