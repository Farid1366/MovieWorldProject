namespace Entities.Dtos.CreationDtos
{
    public class MovieForCreationDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PublishYear { get; set; }
        public int Duration { get; set; }
        public decimal? IMDB_Rate { get; set; }
    }
}
