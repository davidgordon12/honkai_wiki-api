using System.ComponentModel.DataAnnotations;

namespace honkai_wiki_api.Models
{
    public class Battlesuit
    {
        [Key]
        public string Name { get; set; }
        public Valkyrie Valkyrie { get; set; }
        public string Rank { get; set; }
        public string Features { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
