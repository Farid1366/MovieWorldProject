using DatabaseLayer.Interfaces;
using DBLibrary;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace DatabaseLayer.Reposetories
{
    public class CastRepo : ICastRepo
    {
        private readonly MovieWorldDbContext _context;
        public CastRepo(MovieWorldDbContext context)
        {
            _context = context;
        }
        public List<Cast> GetCasts(int movieId)
        {
            return _context.Cast
                .Include(c => c.CastMovies)
                .AsNoTracking()
                .AsEnumerable()
                .Where(c => c.CastMovies.Any(mc => mc.MovieId == movieId))
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
