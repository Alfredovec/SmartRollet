using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess.Concrete
{
  public class DbInitializer : DropCreateDatabaseIfModelChanges<RolletContext>
  {
    protected override void Seed(RolletContext context)
    {
      context.Rollets.Add(new Rollet()
      {
        Id = 1,
        Height = 169,
        Width = 100,
        OpenedPart = 0
      });

      base.Seed(context);
    }
  }
}
