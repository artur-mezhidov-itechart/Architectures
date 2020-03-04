using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Profile.Commands
{
    public class UpdatePersonalCommand : CommandBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public string CompanySite { get; set; }

        public string Post { get; set; }

        public string About { get; set; }
    }
}
