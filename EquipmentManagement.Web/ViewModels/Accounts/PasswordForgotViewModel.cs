using System.ComponentModel.DataAnnotations;

namespace EquipmentManagement.Web.ViewModels.Accounts
{
    public class PasswordForgotViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
