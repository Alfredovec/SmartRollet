using System.Data.Entity;
using DataAccess.Models.Entities;

namespace DataAccess.Concrete
{
    public class RolletContext : DbContext
    {
        public RolletContext()
            : base(@"Data Source=.;Initial Catalog=RolletDb;User Id='Sergii_Rud';password='123'")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Rollet> Rollets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Lighter> Lighters { get; set; }
    }
}
