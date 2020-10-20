using System;
using System.Collections.Generic;
using System.Linq;
using GuessGameApi.Model;

namespace GuessGameApi.Repository
{
    public class SqlGuessRepository : IGuessRepository
    {
        private GuessContext _context;

        public SqlGuessRepository(GuessContext context)
        {
            _context = context;
        }

        public void AddGuess(Guess guess)
        {
            if (guess == null)
            {
                throw new ArgumentNullException(nameof(guess));
            }

            _context.Add(guess);
        }

        public void DeleteGuess(Guess guess)
        {
            _context.Remove(guess);
        }

        public IEnumerable<Guess> GetAllGuesses()
        {
            return _context.Guesses.ToList();
        }

        public IEnumerable<Guess> GetGuessesByUId(string uid)
        {
            return _context.Guesses.Where(x => x.UId == uid).ToList();
        }

        public Guess GetGuessById(int id)
        {
            return _context.Guesses.FirstOrDefault(x => x.Id == id);
        }

        public Guess GetLatestGuessByUId(string uid)
        {
            return _context.Guesses
                .Where(x => x.UId == uid)
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}