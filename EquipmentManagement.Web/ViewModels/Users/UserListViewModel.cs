using System.Linq;
using EquipmentManagement.Application.Users.Queries.Models;

namespace EquipmentManagement.Web.ViewModels.Users
{
    public class UserListViewModel
    {
        public IQueryable<UserInfo> Users { get; set; }
    }
}
