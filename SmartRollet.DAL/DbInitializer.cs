using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartRollet.DomainModel.Entities;

namespace SmartRollet.DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<RolletContext>
    {
        protected override void Seed(RolletContext context)
        {
            context.Rollets.Add(new Rollet()
            {
                Height = 100,
                Width = 200
            });

            base.Seed(context);
        }
    }
}
