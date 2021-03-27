using Microsoft.AspNetCore.Identity;
using TouristSpotsDomain.Entities.Security;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class UserService : ServiceBase<AppUser>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository modelRepository) : base(modelRepository)
        {
            _repository = modelRepository;
        }
    }
}