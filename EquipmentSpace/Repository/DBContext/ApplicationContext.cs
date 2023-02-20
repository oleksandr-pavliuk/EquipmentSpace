using EquipmentSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSpace.Repository.DBContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Space> Spaces { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
