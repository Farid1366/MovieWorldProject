using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos.CreationDtos
{
    public class MovieForCreationDto
    {
        [Required(ErrorMessage = "Movie name is a required field")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Movie publish year is a required field")]
        public string? PublishYear { get; set; }
        [Required(ErrorMessage = "Movie duration is a required field")]
        public int Duration { get; set; }
        [Required(ErrorMessage = "Movie IMDB_Rate is a required field")]
        public decimal? IMDB_Rate { get; set; }
    }
}
