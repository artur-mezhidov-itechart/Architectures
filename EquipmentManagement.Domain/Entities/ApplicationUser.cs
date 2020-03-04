using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EquipmentManagement.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string StateOrProvince { get; set; }

        public string Locality { get; set; }

        public string Postcode { get; set; }

        public string StreetAddress { get; set; }

        public string CompanyName { get; set; }

        public string CompanySite { get; set; }

        public string Post { get; set; }

        public string About { get; set; }

        public string AvatarUrl { get; set; }

        public ICollection<Request> Requests { get; set; }

        public ICollection<UserEquipment> Equipments { get; set; }
    }
}
