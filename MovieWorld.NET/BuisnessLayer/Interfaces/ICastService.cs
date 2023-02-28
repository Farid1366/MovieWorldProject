using Model.DTOs;

namespace BuisnessLayer.Interfaces
{
    public interface ICastService
    {
        List<CastDto> GetCasts(int movieId);
    }
}
