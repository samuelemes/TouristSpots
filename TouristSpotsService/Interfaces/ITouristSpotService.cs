using Sistema.Domain.Interfaces.Services;
using System.Collections.Generic;
using TouristSpotsDomain.Entities;

namespace TouristSpotsService.Interfaces
{
    public interface ITouristSpotService : IServiceBase<TouristSpot>
    {
        IEnumerable<TouristSpot> GetByName(TouristSpot filter);

        //Definir Servicos padroes para as classes herdeiras
        TouristSpot Create(TouristSpot model);
    }
}
