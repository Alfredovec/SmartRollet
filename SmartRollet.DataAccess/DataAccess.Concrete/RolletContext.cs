using System.Data.Entity;
using DataAccess.Concrete;
using DataAccess.Models;

namespace DataAccess.Concrete
{
    public class RolletContext : DbContext
    {
        public RolletContext()
            : base(@"Data Source=(localdb)\v11.0; AttachDbFilename=|DataDirectory|\RolletDb.mdf; Integrated Security=True")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Rollet> Rollets { get; set; }
    }
}
