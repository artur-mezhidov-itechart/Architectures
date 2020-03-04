using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Security
{
    public static class SecurityServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimsPrincipalFactory>();
            services.AddScoped<IUserContext, UserContext>();

            return services;
        }
    }
}
