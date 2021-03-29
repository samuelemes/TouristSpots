using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class FavoriteTouristSpotService : ServiceBase<FavoriteTouristSpot>, IFavoriteTouristSpotService
    {
        private readonly IFavoriteTouristSpotRepository _repository;

        public FavoriteTouristSpotService(IFavoriteTouristSpotRepository modelRepository) : base(modelRepository)
        {
            _repository = modelRepository;
        }

        public IEnumerable<FavoriteTouristSpot> getByUser(int idUsuario)
        {
            return _repository.getByUser(idUsuario);
        }
    }
}