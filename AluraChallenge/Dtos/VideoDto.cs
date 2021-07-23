using System.ComponentModel.DataAnnotations;

namespace AluraFlix.Controllers
{
    public class VideoDto
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Url { get; set; }

    }
}