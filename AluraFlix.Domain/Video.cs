using System;
using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Domain
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        [Range(2, 30)]
        public string Titulo { get; set; }
        [Required]
        [Range(20, 200)]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }

    }
}
