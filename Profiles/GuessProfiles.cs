using AutoMapper;
using GuessGameApi.Dtos;
using GuessGameApi.Model;

namespace GuessGameApi.Profiles
{
    public class GuessProfiles : Profile
    {
        public GuessProfiles()
        {
            CreateMap<Guess, GuessReadDto>();

            CreateMap<GuessWriteDto, Guess>();

            CreateMap<Guess, GuessWriteDto>();
        }
    }
}