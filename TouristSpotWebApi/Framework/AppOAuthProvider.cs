using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GDC.Senar.ATeG.ConsoleServer.Identity.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using TouristSpotsDomain.Entities.Security;

namespace GDC.Senar.ATeG.ConsoleServer.Identity
{
    public sealed class AppOAuthProvider : OAuthAuthorizationServerProvider
    {
        #region Fields

        private readonly string _publicClientId;

        #endregion

        #region Constructors and Destructors

        public AppOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
                throw new ArgumentNullException("publicClientId");

            _publicClientId = publicClientId;
        }

        #endregion

        #region Public Methods and Operators

        public static AuthenticationProperties CreateProperties(AppUser user)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
                                               {
                                                   {"username", user.UserName},
                                                   //{"id", Convert.ToString(user.Pessoa.Id)}
                                               };
            return new AuthenticationProperties(data);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<AppUserManager>();

            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha estão incorretos.");
                return;
            }

            //if (user.IdPessoa != null)
            //{
            //    context.SetError("unlinked_user", "Usuário não possui pessoa vinculada.");
            //    return;
            //}

            var oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, OAuthDefaults.AuthenticationType);
            var cookiesIdentity =
                await user.GenerateUserIdentityAsync(userManager, CookieAuthenticationDefaults.AuthenticationType);
            var properties = CreateProperties(user);
            var ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Properties.Dictionary)
                context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                var expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                    context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        #endregion
    }
}