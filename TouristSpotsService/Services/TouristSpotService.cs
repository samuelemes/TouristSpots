using System.Collections.Generic;
using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class TouristSpotService : ServiceBase<TouristSpot>, ITouristSpotService
    {
        private readonly ITouristSpotRepository _repository;

        public TouristSpotService(ITouristSpotRepository modelRepository) : base(modelRepository)
        {
            _repository = modelRepository;
        }

        public IEnumerable<TouristSpot> GetByName(TouristSpot filter)
        {
            return _repository.getByName(filter);
        }
    }
}