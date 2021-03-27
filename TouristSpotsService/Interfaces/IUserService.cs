using Microsoft.AspNetCore.Identity;
using Sistema.Domain.Interfaces.Services;
using TouristSpotsDomain.Entities.Security;

namespace TouristSpotsService.Interfaces
{
    public interface IUserService : IServiceBase<AppUser>
    {
        //Definir Servicos padroes para as classes herdeiras
    }
}
