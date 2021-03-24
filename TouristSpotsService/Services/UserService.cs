using Microsoft.AspNetCore.Identity;
using TouristSpotsDomain.Interface.Repositories;
using TouristSpotsService.Interfaces;

namespace TouristSpotsService
{
    public class UserService : ServiceBase<IdentityUser<int>>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository modelRepository) : base(modelRepository)
        {
            _repository = modelRepository;
        }
    }
}