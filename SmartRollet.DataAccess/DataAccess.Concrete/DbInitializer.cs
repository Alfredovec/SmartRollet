using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using DataAccess.Models.Entities;

namespace DataAccess.Concrete
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<RolletContext>
    {
        protected override void Seed(RolletContext context)
        {
            var user = new User { Email = "rud.sergey.v@gmail.com" };

            context.Users.Add(user);
            context.Rollets.AddRange(new[] {
                new Rollet
                {
                    User = user,
                    Lighter = new Lighter()
                },
                new Rollet
                {
                    User = user,
                    Lighter = new Lighter()
                }
            });

            base.Seed(context);
        }
    }
}
