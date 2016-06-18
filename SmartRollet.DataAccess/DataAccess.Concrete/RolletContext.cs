using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess.Concrete
{
  public class RolletContext : DbContext
  {
    public RolletContext()
        : base(@"Data Source=.;Initial Catalog=RolletDb;User Id='Sergii_Rud';password='123'")
    {
      Database.SetInitializer(new DbInitializer());
    }

    public DbSet<Rollet> Rollets { get; set; }
  }
}
