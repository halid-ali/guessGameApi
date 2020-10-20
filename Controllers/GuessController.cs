using System;
using System.Collections.Generic;
using AutoMapper;
using GuessGameApi.Dtos;
using GuessGameApi.Model;
using GuessGameApi.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;

namespace GuessGameApi.Controllers
{
    //api/guesses
    [Route("api/guesses")]
    [ApiController]
    public class GuessController : ControllerBase
    {
        private readonly IGuessRepository _repository;

        private readonly IMapper _mapper;

        public GuessController(IGuessRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //api/guesses
        [HttpGet]
        public ActionResult<IEnumerable<GuessReadDto>> GetAllGuesses()
        {
            var allGuesses = _repository.GetAllGuesses();

            return Ok(_mapper.Map<IEnumerable<GuessReadDto>>(allGuesses));
        }

        //api/guesses/id/{id}
        [HttpGet("{id}", Name = "GetGuessById")]
        public ActionResult<GuessReadDto> GetGuessById(int id)
        {
            var guessFromDB = _repository.GetGuessById(id);

            if (guessFromDB == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GuessReadDto>(guessFromDB));
        }

        //api/guesses/uid/{uid}
        [HttpGet("uid/{uid}", Name = "GetGuessesByUId")]
        public ActionResult<IEnumerable<GuessReadDto>> GetGuessesByUId(string uid)
        {
            var guessesByUId = _repository.GetGuessesByUId(uid);

            return Ok(_mapper.Map<IEnumerable<GuessReadDto>>(guessesByUId));
        }

        //api/guesses/uid/{uid}/latest
        [HttpGet("uid/{uid}/latest", Name = "GetLatestGuessByUId")]
        public ActionResult<GuessReadDto> GetLatestGuessByUId(string uid)
        {
            var latestGuess = _repository.GetLatestGuessByUId(uid);

            if (latestGuess == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GuessReadDto>(latestGuess));
        }

        [HttpPost]
        public ActionResult<GuessReadDto> AddGuess(GuessWriteDto guess)
        {
            var guessForDB = _mapper.Map<Guess>(guess);
            guessForDB.DateTime = DateTime.Now;

            _repository.AddGuess(guessForDB);
            _repository.SaveChanges();

            var guessForApi = _mapper.Map<GuessReadDto>(guessForDB);

            return CreatedAtRoute(nameof(GetGuessById), new { Id = guessForApi.Id }, guessForApi);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGuess(int id)
        {
            var guessToDelete = _repository.GetGuessById(id);

            if (guessToDelete == null)
            {
                return NotFound();
            }

            _repository.DeleteGuess(guessToDelete);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult UpdateGuess(int id, JsonPatchDocument<GuessWriteDto> patchData)
        {
            var guessFromDB = _repository.GetGuessById(id);

            if (guessFromDB == null)
            {
                return NotFound();
            }

            var guessToPatch = _mapper.Map<GuessWriteDto>(guessFromDB);
            patchData.ApplyTo(guessToPatch, ModelState);

            if (!TryValidateModel(guessToPatch))
            {
                return ValidationProblem(ModelState);
            }

            //Updates object in repository
            _mapper.Map(guessToPatch, guessFromDB);

            _repository.SaveChanges();
            return NoContent();
        }
    }
}