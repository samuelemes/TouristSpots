using System.Collections.Generic;
using System.Linq;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class FavoriteTouristSpotRepository : RepositoryBase<FavoriteTouristSpot>, IFavoriteTouristSpotRepository
    {
        public IEnumerable<FavoriteTouristSpot> getByUser(FavoriteTouristSpot filter)
        {
            return (DbContext.FavoriteTouristSpot.Where(p => p.idUsuario == filter.idUsuario).ToList());
        }
    }
}
