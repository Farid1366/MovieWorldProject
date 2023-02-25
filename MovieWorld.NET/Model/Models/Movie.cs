using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model.Abstracts;
using Model.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Movie : FullAuditModel
    {
        [StringLength(ModelConstants.MAX_NAME_LENGTH)]
        [Required]
        public string? Name { get; set; }
        [StringLength(ModelConstants.MAX_DESCRIPTION_LENGTH)]
        public string? Description { get; set; }
        [StringLength(ModelConstants.MAX_YEAR_LENGTH,MinimumLength = ModelConstants.MIN_YEAR_LENGTH)]
        [Required]
        public string? PublishYear { get; set; }
        [Required]
        public int Duration { get; set; }
        [Range(ModelConstants.MINIMUM_IMDB_RATE, ModelConstants.MAXIMUM_IMDB_RATE)]
        [Column(TypeName = "decimal(3, 1)")]
        [Required]
        public decimal? IMDB_Rate { get; set; }
        public virtual List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
