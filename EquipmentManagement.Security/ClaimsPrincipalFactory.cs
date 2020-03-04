using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Security
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            ClaimsPrincipal principal = await base.CreateAsync(user);
            bool isAdmin = await UserManager.IsInRoleAsync(user, SystemRoles.ADMIN);

            if (principal.Identity is ClaimsIdentity identity)
            {
                identity.AddClaims(new[] {
                    new Claim(ClaimTypes.GivenName, user.FirstName ?? ""),
                    new Claim(ClaimTypes.Surname, user.LastName ?? ""),
                    new Claim(ClaimTypes.Email, user.Email ?? ""),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                    new Claim(ClaimTypes.Country, user.Country ?? ""),
                    new Claim(ClaimTypes.StateOrProvince, user.StateOrProvince ?? ""),
                    new Claim(ClaimTypes.Locality, user.Locality ?? ""),
                    new Claim(ClaimTypes.PostalCode, user.Postcode ?? ""),
                    new Claim(ClaimTypes.StreetAddress, user.StreetAddress ?? ""),
                    new Claim(AdditionalClaimTypes.CompanyName, user.CompanyName ?? ""),
                    new Claim(AdditionalClaimTypes.CompanySite, user.CompanySite ?? ""),
                    new Claim(AdditionalClaimTypes.Post, user.Post ?? ""),
                    new Claim(AdditionalClaimTypes.About, user.About ?? ""),
                    new Claim(AdditionalClaimTypes.AvatarUrl, user.AvatarUrl ?? ""),
                    new Claim(AdditionalClaimTypes.IsAdmin, isAdmin.ToString())
                });
            }

            return principal;
        }
    }
}
