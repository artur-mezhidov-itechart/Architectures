namespace EquipmentManagement.Application.Users.Queries.Models
{
    public class UserInfo
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string StateOrProvince { get; set; }

        public string Locality { get; set; }

        public string Postcode { get; set; }

        public string StreetAddress { get; set; }

        public string CompanyName { get; set; }

        public string CompanySite { get; set; }

        public string Post { get; set; }

        public string About { get; set; }
        
        public int FurnituresCount { get; set; }

        public int DevicesCount { get; set; }

        public int AccessoriesCount { get; set; }

        public int ToolsCount { get; set; }

        public int PendingRequestsCount { get; set; }

        public double Expenses { get; set; }
    }
}
