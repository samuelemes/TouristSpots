using System;
using System.Security.Claims;

namespace TouristSpotsApi.Framework
{
    public sealed class AppClaimsPrincipal : ClaimsPrincipal
    {
        #region Constructors and Destructors

        public AppClaimsPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        #endregion

        #region Public Properties

        public Guid UserId => Guid.Parse(FindFirst(ClaimTypes.Sid).Value);
        #endregion
    }
}