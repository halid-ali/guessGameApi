using System.Data.Entity;
using GuessGameApi.GitIgnoreCode;
using GuessGameApi.Model;
using MySql.Data.EntityFramework;

namespace GuessGameApi.Repository.MySqlRepo
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlGuessContext : DbContext
    {
        public MySqlGuessContext() : base(ConnectionString.MySqlConnection)
        {

        }

        public DbSet<Guess> Guesses { get; set; }
    }
}