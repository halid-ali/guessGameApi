using System.ComponentModel.DataAnnotations;

namespace GuessGameApi.Dtos
{
    public class GuessWriteDto
    {
        [Required]
        [MaxLength(40)]
        public string UId { get; set; }

        [Required]
        [MaxLength(9)]
        public string Number { get; set; }

        [Required]
        public int GuessCount { get; set; }
    }
}