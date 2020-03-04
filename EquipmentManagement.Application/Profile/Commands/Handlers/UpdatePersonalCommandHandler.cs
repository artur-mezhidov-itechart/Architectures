using System.Threading;
using Microsoft.AspNetCore.Identity;
using EquipmentManagement.Application.Common;
using EquipmentManagement.Domain.Data;
using EquipmentManagement.Domain.Entities;
using EquipmentManagement.Security;

namespace EquipmentManagement.Application.Profile.Commands.Handlers
{
    public class UpdatePersonalCommandHandler : CommandHandler<UpdatePersonalCommand>
    {
        private readonly IUserContext userContext;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UpdatePersonalCommandHandler(DataContext dataContext, IUserContext userContext, SignInManager<ApplicationUser> signInManager) : base(dataContext)
        {
            this.userContext = userContext;
            this.signInManager = signInManager;
        }

        protected override void OnHandling(UpdatePersonalCommand command, CancellationToken token)
        {
            ApplicationUser user = signInManager.UserManager.FindByIdAsync(userContext.UserId).GetAwaiter().GetResult();

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Post = command.Post;
            user.Email = command.Email;
            user.PhoneNumber = command.PhoneNumber;
            user.CompanyName = command.CompanyName;
            user.CompanySite = command.CompanySite;
            user.About = command.About;

            signInManager.UserManager.UpdateAsync(user).GetAwaiter().GetResult();
            signInManager.RefreshSignInAsync(user).GetAwaiter().GetResult();
        }
    }
}
