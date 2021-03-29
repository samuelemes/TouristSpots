using System.Collections.Generic;
using TouristSpotsDomain.Entities;

namespace TouristSpotsDomain.Interface.Repositories
{
    public interface IFavoriteTouristSpotRepository : IRepositoryBase<FavoriteTouristSpot>
    {
        IEnumerable<FavoriteTouristSpot> getByUser(int idUsuario);
    }
}
