using EquipmentSpace.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentSpace.Repository.DBContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Space> Spaces { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-P3761FAKFQC;DataBase=EqSpaceDB;Trusted_Connection=True;Encrypt=False;");
        }

    }
}
