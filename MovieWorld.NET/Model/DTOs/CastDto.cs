namespace Model.DTOs
{
    public class CastDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Height { get; set; }
    }
}
