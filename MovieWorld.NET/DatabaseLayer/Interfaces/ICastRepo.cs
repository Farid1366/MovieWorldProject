using Model.Models;

namespace DatabaseLayer.Interfaces
{
    public interface ICastRepo
    {
        List<Cast> GetCasts(int movieId);
    }
}
