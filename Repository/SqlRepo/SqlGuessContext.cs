using GuessGameApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GuessGameApi.Repository.SqlRepo
{
    public class SqlGuessContext : DbContext
    {
        public SqlGuessContext(DbContextOptions<SqlGuessContext> opts) : base(opts)
        {
            
        }

        public DbSet<Guess> Guesses { get; set; }
    }
}