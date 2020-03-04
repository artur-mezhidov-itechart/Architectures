using System.Threading;
using Microsoft.AspNetCore.Identity;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Profile.Commands.Handlers
{
    public class UpdateLocationCommandHandler : CommandHandler<UpdateLocationCommand>
    {
        private readonly IUserContext userContext;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UpdateLocationCommandHandler(DataContext dataContext, IUserContext userContext, SignInManager<ApplicationUser> signInManager) : base(dataContext)
        {
            this.userContext = userContext;
            this.signInManager = signInManager;
        }

        protected override void OnHandling(UpdateLocationCommand command, CancellationToken token)
        {
            ApplicationUser user = signInManager.UserManager.FindByIdAsync(userContext.UserId).GetAwaiter().GetResult();

            user.Country = command.Country;
            user.StateOrProvince = command.StateOrProvince;
            user.Locality = command.Locality;
            user.StreetAddress = command.StreetAddress;
            user.Postcode = command.Postcode;

            signInManager.UserManager.UpdateAsync(user).GetAwaiter().GetResult();
            signInManager.RefreshSignInAsync(user).GetAwaiter().GetResult();
        }
    }
}
