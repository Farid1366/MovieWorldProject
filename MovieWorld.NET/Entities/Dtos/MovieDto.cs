namespace Model.DTOs
{
    public  class MovieDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PublishYear { get; set; }
        public int Duration { get; set; }
        public decimal? IMDB_Rate { get; set; }
        public override string ToString()
        {
            return $"{Name,-25} | {Description}";
        }
    }
}
