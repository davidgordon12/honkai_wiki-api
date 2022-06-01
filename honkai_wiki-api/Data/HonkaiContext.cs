using honkai_wiki_api.Models;
using Microsoft.EntityFrameworkCore;

namespace honkai_wiki_api.Data
{
    public class HonkaiContext : DbContext
    {
        public static string conString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }

        public DbSet<Battlesuit> Battlesuits { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Valkyrie> Valkyrie { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Stigmata> Stigmata { get; set; }
    }
}
