using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    [Table("MovieCast")]
    [Index(nameof(MovieId), nameof(CastId), IsUnique = true)]
    public class MovieCast
    {
        public int Id { get; set; }
        public int? CastTypeId { get; set; }
        public virtual CastType? CastType { get; set; }
        public virtual int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual int CastId { get; set; }
        public virtual Cast? Cast { get; set; }
    }
}
