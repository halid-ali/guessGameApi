using System.Collections.Generic;
using GuessGameApi.Model;

namespace GuessGameApi.Repository
{
    public interface IGuessRepository
    {
        Guess GetGuessById(int id);

        Guess GetLatestGuessByUId(string uid);

        IEnumerable<Guess> GetGuessesByUId(string uid);

        IEnumerable<Guess> GetAllGuesses();

        void AddGuess(Guess guess);

        void DeleteGuess(Guess guess);

        void SaveChanges();
    }
}