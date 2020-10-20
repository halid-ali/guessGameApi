using GuessGameApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GuessGameApi.Repository
{
    public class GuessContext : DbContext
    {
        public GuessContext(DbContextOptions<GuessContext> opts) : base(opts)
        {
            
        }

        public DbSet<Guess> Guesses { get; set; }
    }
}