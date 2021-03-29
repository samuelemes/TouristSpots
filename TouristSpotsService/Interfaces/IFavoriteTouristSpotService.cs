using Sistema.Domain.Interfaces.Services;
using System.Collections.Generic;
using TouristSpotsDomain.Entities;

namespace TouristSpotsService.Interfaces
{
    public interface IFavoriteTouristSpotService : IServiceBase<FavoriteTouristSpot>
    {
        //Definir Servicos padroes para as classes herdeiras
        IEnumerable<FavoriteTouristSpot> getByUser(int idUsuario);
    }
}
