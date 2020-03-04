using System;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace EquipmentManagement.Security
{
    public class UserContext : UserContextBase, IUserContext
    {
        private readonly IHttpContextAccessor accessor;

        public UserContext(IHttpContextAccessor accessor = null)
        {
            this.accessor = accessor;
        }

        public string UserId => GetClaimValue(ClaimTypes.NameIdentifier);

        public string UserName => GetClaimValue(ClaimTypes.Name);

        public string FirstName => GetClaimValue(ClaimTypes.GivenName);

        public string LastName => GetClaimValue(ClaimTypes.Surname);

        public string Email => GetClaimValue(ClaimTypes.Email);

        public string PhoneNumber => GetClaimValue(ClaimTypes.MobilePhone);

        public string Country => GetClaimValue(ClaimTypes.Country);

        public string StateOrProvince => GetClaimValue(ClaimTypes.StateOrProvince);

        public string Locality => GetClaimValue(ClaimTypes.Locality);

        public string Postcode => GetClaimValue(ClaimTypes.PostalCode);

        public string StreetAddress => GetClaimValue(ClaimTypes.StreetAddress);

        public string CompanyName => GetClaimValue(AdditionalClaimTypes.CompanyName);

        public string CompanySite => GetClaimValue(AdditionalClaimTypes.CompanySite);

        public string Post => GetClaimValue(AdditionalClaimTypes.Post);

        public string About => GetClaimValue(AdditionalClaimTypes.About);

        public string AvatarUrl => GetClaimValue(AdditionalClaimTypes.AvatarUrl);

        public bool IsAdmin => GetClaimValueBool(AdditionalClaimTypes.IsAdmin);

        protected override ClaimsPrincipal User => Thread.CurrentPrincipal as ClaimsPrincipal
            ?? accessor?.HttpContext.User
            ?? throw new Exception("Does not support principals.");

        protected override ClaimsIdentity Identity => User.Identity as ClaimsIdentity 
            ?? throw new Exception("Current principal does not support claims.");
    }
}
