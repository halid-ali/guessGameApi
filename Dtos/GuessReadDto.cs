using System;

namespace GuessGameApi.Dtos
{
    public class GuessReadDto
    {
        public int Id { get; set; }

        public string UId { get; set; }

        public string Number { get; set; }

        public int GuessCount { get; set; }

        public DateTime DateTime { get; set; }
    }
}