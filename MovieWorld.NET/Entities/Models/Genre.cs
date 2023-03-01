using Model.Abstracts;
using Model.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Genre : FullAuditModel
    {
        [Required]
        [StringLength(ModelConstants.MAX_GENRENAME_LENGTH)]
        public string? Name { get; set; }
        public virtual List<MovieGenre> GenreMovies { get; set; } = new List<MovieGenre>();
    }
}
