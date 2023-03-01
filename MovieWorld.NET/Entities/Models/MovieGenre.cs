using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [Table("MovieGenre")]
    [Index(nameof(MovieId), nameof(GenreId), IsUnique = true)]
    public class MovieGenre
    {
        public int Id { get; set; }
        public virtual int MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
    }
}
