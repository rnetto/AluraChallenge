using System;
using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Domain
{
    public class Video
    {
        public int Id { get; set; }
        [Required]
        [Range(2, 50)]
        public string Titulo { get; set; }
        [Required]
        [Range(10, 200)]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }

    }
}
