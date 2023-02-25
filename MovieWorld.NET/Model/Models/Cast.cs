using Model.Abstracts;
using Model.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Cast : FullAuditModel
    {
        [StringLength(ModelConstants.MAX_CAST_NAME_LENGTH)]
        [Required]
        public string? Name { get; set; }
        [StringLength(ModelConstants.MAX_DESCRIPTION_LENGTH)]
        public string? Description { get; set; }
        [Required]
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "decimal(3, 2)")]
        [Required]
        public decimal? Height { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual List<MovieCast> CastMovies { get; set; } = new List<MovieCast>();
    }
}
