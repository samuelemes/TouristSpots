// #################################################
// GDC TECNOLOGIA E SERVIÇOS
// Projeto: GDC.Sernar.ATeG.Api
// Criado por: Leandro Guimarães Fernandes
// #################################################

namespace GDC.Sernar.ATeG.Api.Framework.Identity.Models
{
    public class LoginViewModel
    {
        #region Properties

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        #endregion
    }
}