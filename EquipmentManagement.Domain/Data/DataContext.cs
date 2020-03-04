using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EquipmentManagement.Domain.Entities;

namespace EquipmentManagement.Domain.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<UserEquipment> UserEquipments { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestStatusInfo> RequestStatusInfo { get; set; }

        public DbSet<History> Histories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
