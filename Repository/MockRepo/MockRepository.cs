using System;
using System.Collections.Generic;
using System.Linq;
using GuessGameApi.Model;

namespace GuessGameApi.Repository.MockRepo
{
    public class MockRepository : IGuessRepository
    {
        List<Guess> guesses = new List<Guess>
        {
            new Guess
            {
                Id = 1,
                UId = "q1w2e3r4",
                Number = 12345,
                GuessCount = 19,
                DateTime = DateTime.Now
            },
            new Guess
            {
                Id = 2,
                UId = "5t6z7u8i",
                Number = 67890,
                GuessCount = 71,
                DateTime = DateTime.UtcNow
            },
            new Guess
            {
                Id = 3,
                UId = "q1w2e3r4",
                Number = 10292,
                GuessCount = 11,
                DateTime = DateTime.Now.AddDays(1)
            }
        };

        public void AddGuess(Guess guess)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteGuess(Guess guess)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Guess> GetAllGuesses()
        {
            return guesses;
        }

        public IEnumerable<Guess> GetGuessesByUId(string uid)
        {
            return guesses.Where(x => x.UId == uid).ToList();
        }

        public Guess GetGuessById(int id)
        {
            return guesses.Where(x => x.Id == id).FirstOrDefault();
        }

        public Guess GetLatestGuessByUId(string uid)
        {
            return guesses
                .Where(x => x.UId == uid)
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefault();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}