using TouristSpotsDomain.Entities;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class TouristSpotPhotoService : ServiceBase<TouristSpotPhoto>, ITouristSpotPhotoService
    {
        private readonly ITouristSpotPhotoRepository _repository;

        public TouristSpotPhotoService(ITouristSpotPhotoRepository modelRepository) : base(modelRepository)
        {
            _repository = modelRepository;
        }
    }
}