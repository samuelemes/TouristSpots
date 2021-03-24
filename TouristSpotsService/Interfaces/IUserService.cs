using Microsoft.AspNetCore.Identity;
using Sistema.Domain.Interfaces.Services;

namespace TouristSpotsService.Interfaces
{
    public interface IUserService : IServiceBase<IdentityUser<int>>
    {
        //Definir Servicos padroes para as classes herdeiras
    }
}
