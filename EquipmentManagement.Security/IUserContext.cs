namespace EquipmentManagement.Security
{
    public interface IUserContext
    {
        string UserId { get; }

        string UserName { get; }

        string Email { get; }

        string PhoneNumber { get; }

        string FirstName { get; }

        string LastName { get; }

        string Country { get; }

        string StateOrProvince { get; }

        string Locality { get; }

        string Postcode { get; }

        string StreetAddress { get; }

        string CompanyName { get; }

        string CompanySite { get; }

        string Post { get; }

        string About { get; }

        string AvatarUrl { get; }

        bool IsAdmin { get; }
    }
}
