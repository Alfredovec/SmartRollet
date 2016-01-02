using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess.Concrete
{
    public class DbInitializer : DropCreateDatabaseAlways<RolletContext>
    {
        protected override void Seed(RolletContext context)
        {
            context.Rollets.Add(new Rollet()
            {
                Height = 42,
                Width = 42
            });

            base.Seed(context);
        }
    }
}
