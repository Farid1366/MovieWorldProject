namespace Entities.Models.Exceptions
{
    public sealed class MovieNotFoundException : NotFoundException 
    { 
        public MovieNotFoundException(int movieId) : base($"The movie with id: {movieId} doesn't exist in the database.") 
        { } 
    }
}
