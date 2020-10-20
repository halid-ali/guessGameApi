using System;
using System.ComponentModel.DataAnnotations;

namespace GuessGameApi.Model
{
    public class Guess
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string UId { get; set; }

        [Required]
        [MaxLength(9)]
        public string Number { get; set; }

        [Required]
        public int GuessCount { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm.ss}")]
        public DateTime DateTime { get; set; }
    }
}