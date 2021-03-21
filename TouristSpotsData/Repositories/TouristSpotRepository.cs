using System.Collections.Generic;
using System.Linq;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;

namespace TouristSpotsData.Repositories
{
    public class TouristSpotRepository : RepositoryBase<TouristSpot>, ITouristSpotRepository
    {
        public IEnumerable<TouristSpot> getByName(TouristSpot filter)
        {
            return (DbContext.TouristSpot.Where(p => p.nome.Contains(filter.nome)).ToList());
        }
    }
}
