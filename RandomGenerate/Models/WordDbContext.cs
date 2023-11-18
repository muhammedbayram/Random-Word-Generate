using Microsoft.EntityFrameworkCore;

namespace RandomGenerate.Models
{
    public class WordDbContext : DbContext
    {

        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        {

        }

        public DbSet<Word> Words { get; set; }
    }
}
