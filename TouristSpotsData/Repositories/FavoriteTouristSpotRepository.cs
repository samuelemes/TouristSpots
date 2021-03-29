using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class FavoriteTouristSpotRepository : RepositoryBase<FavoriteTouristSpot>, IFavoriteTouristSpotRepository
    {
        public IEnumerable<FavoriteTouristSpot> getByUser(int idUsuario)
        {
            var list = (DbContext.FavoriteTouristSpot.Include(i => i.TouristSpots).Where(p => p.idUsuario == idUsuario).ToList());

            return list;
        }
    }
}
