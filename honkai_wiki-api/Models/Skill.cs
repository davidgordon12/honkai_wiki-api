namespace honkai_wiki.Models
{
    public class Skill
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SP { get; set; } = 0;
        public int CD { get; set; } = 0;
        public int UnlockedAt { get; set; } = 0;
    }
}
