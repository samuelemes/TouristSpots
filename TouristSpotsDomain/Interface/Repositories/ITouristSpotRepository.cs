using System.Collections.Generic;
using TouristSpotsDomain.Entities;

namespace TouristSpotsDomain.Interface.Repositories
{
    public interface ITouristSpotRepository : IRepositoryBase<TouristSpot>
    {
        IEnumerable<TouristSpot> getByName(TouristSpot filter);
        IEnumerable<TouristSpot> getTouristSpotsByRadius(double lat, double lng, double radius);
    }
}
