using EquipmentManagement.Infrastructura.Commands;

namespace EquipmentManagement.Application.Profile.Commands
{
    public class UpdateLocationCommand : CommandBase
    {
        public string StreetAddress { get; set; }

        public string Postcode { get; set; }

        public string Locality { get; set; }

        public string StateOrProvince { get; set; }

        public string Country { get; set; }
    }
}
